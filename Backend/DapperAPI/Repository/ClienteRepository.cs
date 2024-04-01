using Dapper;
using DapperAPI.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public ClienteRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Cliente cliente)
        {

            string query = "INSERT INTO Cliente (Nombres,Apellidos,Direccion,Telefono) VALUES (@Nombres, @Apellidos, @Direccion, @Telefono)";
            var parameters = new DynamicParameters();
            parameters.Add("Nombres", cliente.Nombres, DbType.String);
            parameters.Add("Apellidos", cliente.Apellidos, DbType.String);
            parameters.Add("Direccion", cliente.Direccion, DbType.String);
            parameters.Add("Telefono", cliente.Telefono, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        
        public async Task<List<Cliente>> GetAll()
        {
            string query = "SELECT * FROM Cliente";
            using (var conx = _context.CreateConnection()) {
                var cllist = await conx.QueryAsync<Cliente>(query);
                return cllist.ToList();
            }
        }

        public async Task<Cliente> GetById(int code)
        {
            string query = "SELECT * FROM Cliente where Id = @code";
            using (var conx = _context.CreateConnection())
            {
                var cllist = await conx.QueryFirstOrDefaultAsync<Cliente>(query, new { code });
                return cllist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string reponse = string.Empty;
            string query = "DELETE FROM Cliente where id = @id";
            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, new { code });
                reponse = "pass";
            }
            return reponse;
        }

        public async Task<List<Cliente>> SPGetById(int code)
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
                var cllist = await conx.QueryAsync<Cliente>(query, new { code }, commandType:CommandType.StoredProcedure);
                return cllist.ToList();
            }

        }

        public async Task<string> Update(Cliente cliente, int code)
        {
            string query = "UPDATE SET Cliente Nombres=@Nombres, Apellidos=@Apellidos, Direccion=@Direccion, Telefono=@Telefono WHERE Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", code, DbType.Int32);
            parameters.Add("Nombres", cliente.Nombres, DbType.String);
            parameters.Add("Apellidos", cliente.Apellidos, DbType.String);
            parameters.Add("Direccion", cliente.Direccion, DbType.String);
            parameters.Add("Telefono", cliente.Telefono, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
