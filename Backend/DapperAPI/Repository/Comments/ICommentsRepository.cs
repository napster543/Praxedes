using DapperAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public interface ICommentsRepository
    {
        Task<List<Comments>> GetAll();
        Task<Comments> GetById(int code);
        Task<List<Comments>> SPGetById(int code);
        Task<string> Create(Comments comments);
        Task<string> Update(Comments comments, int code);
        Task<string> Remove(int code);
    }
}
