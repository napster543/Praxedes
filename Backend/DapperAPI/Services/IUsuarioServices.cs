using DapperAPI.Model;
using DapperAPI.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Services
{
    public interface IUsuarioServices
    {
       Task<UsuarioResponse> Aut(AuthRequest model);
        
    }
}
