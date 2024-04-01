using DapperAPI.Model;
using DapperAPI.Model.Request;
using DapperAPI.Model.Response;
using DapperAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Autentication([FromBody] AuthRequest model)
        {
            Respuesta res = new Respuesta();
            var user =  await _usuarioServices.Aut(model);
            if (user == null)
            {
                res.Success = false;
                res.Message = "Usuario o contraseña incorrecta";
                return BadRequest(res);
            }
            res.Success = true;
            res.Data = user;
            return Ok(res);
        }
    }
}
