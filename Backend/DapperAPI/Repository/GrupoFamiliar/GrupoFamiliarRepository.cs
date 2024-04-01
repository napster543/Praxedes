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
    public class GrupoFamiliarRepository : IGrupoFamiliarRepository
    {
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public GrupoFamiliarRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(GrupoFamiliar grupoFamiliar)
        {

            string query = "INSERT INTO GrupoFamiliar (Usuario,Cedula,Nombres,Apellidos,Genero,Parentesco,Edad,MenorEdad,FechaNacimiento) VALUES (@Usuario,@Cedula,@Nombres,@Apellidos,@Genero,@Parentesco,@Edad,@MenorEdad,@FechaNacimiento)";
            var parameters = new DynamicParameters();
            
            parameters.Add("Usuario", grupoFamiliar.Usuario, DbType.String);
            parameters.Add("Cedula", grupoFamiliar.Cedula, DbType.String);
            parameters.Add("Nombres", grupoFamiliar.Nombres, DbType.String);
            parameters.Add("Apellidos", grupoFamiliar.Apellidos, DbType.String);
            parameters.Add("Genero", grupoFamiliar.Genero, DbType.String);
            parameters.Add("Parentesco", grupoFamiliar.Parentesco, DbType.String);
            parameters.Add("Edad", grupoFamiliar.Edad, DbType.String);
            parameters.Add("MenorEdad", grupoFamiliar.MenorEdad, DbType.String);
            parameters.Add("FechaNacimiento", grupoFamiliar.FechaNacimiento, DbType.String);

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        
        public async Task<List<GrupoFamiliar>> GetAll()
        {
            string query = "SELECT * FROM GrupoFamiliar";
            using (var conx = _context.CreateConnection()) {
                var cllist = await conx.QueryAsync<GrupoFamiliar>(query);
                return cllist.ToList();
            }
        }

        public async Task<GrupoFamiliar> GetById(int code)
        {
            string query = "SELECT * FROM GrupoFamiliar where Id = @code";
            using (var conx = _context.CreateConnection())
            {
                var cllist = await conx.QueryFirstOrDefaultAsync<GrupoFamiliar>(query, new { code });
                return cllist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string reponse = string.Empty;
            string query = "DELETE FROM GrupoFamiliar where id = @id";
            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, new { code });
                reponse = "pass";
            }
            return reponse;
        }

        public async Task<List<GrupoFamiliar>> SPGetById(int code)
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
                var cllist = await conx.QueryAsync<GrupoFamiliar>(query, new { code }, commandType:CommandType.StoredProcedure);
                return cllist.ToList();
            }

        }

        public async Task<string> Update(GrupoFamiliar grupoFamiliar, int code)
        {
            string query = "UPDATE SET GrupoFamiliar Usuario = @Usuario,Cedula = @Cedula,Nombres = @Nombres,Apellidos = @Apellidos,Genero = @Genero,Parentesco = @Parentesco,Edad = @Edad,MenorEdad = @MenorEdad,FechaNacimiento = @FechaNacimiento WHERE Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", code, DbType.Int32);
            parameters.Add("Usuario", grupoFamiliar.Usuario, DbType.String);
            parameters.Add("Cedula", grupoFamiliar.Cedula, DbType.String);
            parameters.Add("Nombres", grupoFamiliar.Nombres, DbType.String);
            parameters.Add("Apellidos", grupoFamiliar.Apellidos, DbType.String);
            parameters.Add("Genero", grupoFamiliar.Genero, DbType.String);
            parameters.Add("Parentesco", grupoFamiliar.Parentesco, DbType.String);
            parameters.Add("Edad", grupoFamiliar.Edad, DbType.String);
            parameters.Add("MenorEdad", grupoFamiliar.MenorEdad, DbType.String);
            parameters.Add("FechaNacimiento", grupoFamiliar.FechaNacimiento, DbType.DateTime);
            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
