using DapperAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public interface IJsonplaceholderRepository
    {
        Task<string> GetPost();
        Task<string> GetComment();
        Task<string> CreateComments(List<Comments> model);
        Task<string> CreatePost(List<Post> model);

    }
}
