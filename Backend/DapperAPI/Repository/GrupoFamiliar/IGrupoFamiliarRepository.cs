using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public interface IGrupoFamiliarRepository
    {
        Task<List<GrupoFamiliar>> GetAll();
        Task<GrupoFamiliar> GetById(int code);
        Task<List<GrupoFamiliar>> SPGetById(int code);
        Task<string> Create(GrupoFamiliar cliente);
        Task<string> Update(GrupoFamiliar cliente, int code);
        Task<string> Remove(int code);
    }
}
