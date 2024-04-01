using Dapper;
using DapperAPI.Model;
using DapperAPI.Model.Common;
using DapperAPI.Model.Data;
using DapperAPI.Model.Request;
using DapperAPI.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DapperAPI.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly AppSettings _appSettings;
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public UsuarioServices(DapperDBContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<UsuarioResponse> Aut(AuthRequest model)
        {
            UsuarioResponse res = new UsuarioResponse();
            string sPassword = Encrypt.GetSHA256(model.Password);
            string query = "SELECT * FROM Usuario WHERE Email = @email AND Passd = @password";
            using (var conx = _context.CreateConnection())
            {
               
                var cllist = await conx.QueryFirstAsync<Usuario>(query, new { email = model.Email, password = sPassword });

                    if (cllist == null) return null;

                    res.Email = cllist.Email;
                    res.Token = GetToken(cllist);


            }
            return res;
        }

        private string GetToken(Usuario model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                        new Claim(ClaimTypes.Email,  model.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
