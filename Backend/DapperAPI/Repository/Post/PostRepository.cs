using Dapper;
using DapperAPI.Model;
using DapperAPI.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public PostRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Post post)
        {

            string query = "INSERT INTO Post (userId,id,title,body) VALUES (@userId,@id,@title,@body)";
            var parameters = new DynamicParameters();

            parameters.Add("userId", post.userId, DbType.Int32);
            parameters.Add("id", post.id, DbType.Int32);
            parameters.Add("title", post.title, DbType.String);
            parameters.Add("body", post.body, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        
        public async Task<List<Post>> GetAll()
        {
            string query = "SELECT * FROM Post";
            using (var conx = _context.CreateConnection()) {
                var cllist = await conx.QueryAsync<Post>(query);
                return cllist.ToList();
            }
        }

        public async Task<Post> GetById(int code)
        {
            string query = "SELECT * FROM Post where Id = @code";
            using (var conx = _context.CreateConnection())
            {
                var cllist = await conx.QueryFirstOrDefaultAsync<Post>(query, new { code });
                return cllist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string reponse = string.Empty;
            string query = "DELETE FROM Post where id = @id";
            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, new { code });
                reponse = "pass";
            }
            return reponse;
        }

        public async Task<List<Post>> SPGetById(int code)
        {
            //string query = "EXEC SPCliente @code";
            //using (var conx = _context.CreateConnection())
            //{
            //    var cllist = await conx.QueryAsync<Cliente>(query, new { code });
            //    return cllist.ToList();
            //}

            string query = "EXEC SPCliente @code";
            using (var conx = _context.CreateConnection())
            {
                var cllist = await conx.QueryAsync<Post>(query, new { code }, commandType:CommandType.StoredProcedure);
                return cllist.ToList();
            }

        }

        public async Task<string> Update(Post post, int code)
        {
            string query = "UPDATE SET Post userId = @userId, title = @title, body = @body WHERE Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", code, DbType.Int32);
            parameters.Add("userId", post.userId, DbType.Int32);            
            parameters.Add("title", post.title, DbType.String);
            parameters.Add("body", post.body, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
