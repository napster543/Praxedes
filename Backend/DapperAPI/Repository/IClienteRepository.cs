using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int code);
        Task<List<Cliente>> SPGetById(int code);
        Task<string> Create(Cliente cliente);
        Task<string> Update(Cliente cliente, int code);
        Task<string> Remove(int code);
    }
}
