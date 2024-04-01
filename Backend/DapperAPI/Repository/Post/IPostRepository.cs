using DapperAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetById(int code);
        Task<List<Post>> SPGetById(int code);
        Task<string> Create(Post cliente);
        Task<string> Update(Post cliente, int code);
        Task<string> Remove(int code);
    }
}
