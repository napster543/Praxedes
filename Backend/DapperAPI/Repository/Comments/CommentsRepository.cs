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
    public class CommentsRepository : ICommentsRepository
    {
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public CommentsRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Comments comments)
        {

            string query = "INSERT INTO Post (postId,id,name,email,body) VALUES (@postId,@id,@name,@email,@body)";
            var parameters = new DynamicParameters();

            parameters.Add("id", comments.id, DbType.Int32);
            parameters.Add("postId", comments.postId, DbType.Int32);
            parameters.Add("name", comments.name, DbType.String);
            parameters.Add("email", comments.email, DbType.String);
            parameters.Add("body", comments.body, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        
        public async Task<List<Comments>> GetAll()
        {
            string query = "SELECT * FROM Post";
            using (var conx = _context.CreateConnection()) {
                var cllist = await conx.QueryAsync<Comments>(query);
                return cllist.ToList();
            }
        }

        public async Task<Comments> GetById(int code)
        {
            string query = "SELECT * FROM Post where Id = @code";
            using (var conx = _context.CreateConnection())
            {
                var cllist = await conx.QueryFirstOrDefaultAsync<Comments>(query, new { code });
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

        public async Task<List<Comments>> SPGetById(int code)
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
                var cllist = await conx.QueryAsync<Comments>(query, new { code }, commandType:CommandType.StoredProcedure);
                return cllist.ToList();
            }

        }

        public async Task<string> Update(Comments comments, int code)
        {
            string query = "UPDATE SET Comments postId=@postId,name=@name,email=@email,body=@body WHERE Id=@code";
            var parameters = new DynamicParameters();
            parameters.Add("Id", code, DbType.Int32);
            parameters.Add("postId", comments.postId, DbType.Int32);
            parameters.Add("name", comments.name, DbType.String);
            parameters.Add("email", comments.email, DbType.String);
            parameters.Add("body", comments.body, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
