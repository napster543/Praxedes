using DapperAPI.Repository;
using DapperAPI.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApplicationApi.Models;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JsonplaceholderController : ControllerBase
    {
        private readonly IJsonplaceholderRepository _repo;

        private readonly ILogger<JsonplaceholderController> _logger;

        public JsonplaceholderController(IJsonplaceholderRepository repo, ILogger<JsonplaceholderController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet("GetComments")]
        public  async Task<IActionResult> GetComments()
        {
            var _list = await _repo.GetComment();
            if (_list != null)
            {
                return Ok(_list);
            }
            else {
                return NotFound();
            }
        }
        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var _list = await _repo.GetPost();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
