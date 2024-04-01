using Dapper;
using DapperAPI.Model;
using DapperAPI.Model.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Repository
{
    public class JsonplaceholderRepository : IJsonplaceholderRepository
    {
        private readonly DapperDBContext _context;
        string response = string.Empty;
        public JsonplaceholderRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<string> GetComment()
        {
            
            string url = "https://jsonplaceholder.typicode.com/comments";            
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {             
                    HttpResponseMessage response = await httpClient.GetAsync(url);             
                    if (response.IsSuccessStatusCode)
                    {             
                        string responseBody = await response.Content.ReadAsStringAsync();             
                        List<Comments> comments = JsonConvert.DeserializeObject<List<Comments>>(responseBody);
                        string respuesta = await this.CreateComments(comments);
                    }
                    else
                    {
                        Console.WriteLine($"La solicitud al endpoint {url} falló con el código de estado: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error al realizar la solicitud HTTP: {e.Message}");
                }
            }
            return "hola";
        }


        public async Task<string> GetPost()
        {

            string url = "https://jsonplaceholder.typicode.com/posts";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(responseBody);
                        string respuesta = await this.CreatePost(posts);
                    }
                    else
                    {
                        Console.WriteLine($"La solicitud al endpoint {url} falló con el código de estado: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error al realizar la solicitud HTTP: {e.Message}");
                }
            }
            return "hola";
        }

        public async Task<string> CreateComments(List<Comments> model)
        {
            string query = "INSERT INTO Comments (postId,id,name,email,body) VALUES (@postId,@id,@name,@email,@body)";
          

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, model);
                response = "se creo correctamente";
            }
            return response;
        }
        public async Task<string> CreatePost(List<Post> model)
        {
            string query = "INSERT INTO Post (userId,id,title,body) VALUES (@userId,@id,@title,@body)";
          

            using (var conx = _context.CreateConnection())
            {
                await conx.ExecuteAsync(query, model);
                response = "se creo correctamente";
            }
            return response;
        }

       
    }
}
