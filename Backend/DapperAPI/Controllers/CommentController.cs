using DapperAPI.Model;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentsRepository _repo;

        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentsRepository repo, ILogger<CommentController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public  async Task<IActionResult> GetAll()
        {
            var _list = await _repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else {
                return NotFound();
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _list = await _repo.GetById(id);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Comments comments)
        {
            string _result = string.Empty;
            try
            {
                var validator = new ValidationsComment();
                ValidationResult result = validator.Validate(comments);
                _result = await _repo.Create(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
            return Ok(_result);            
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Comments comments, int id)
        {
            string _result = string.Empty;
            try
            {
                _result = await _repo.Update(comments, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
            
            return Ok(_result);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var _result = await _repo.Remove(id);
            return Ok(_result);
        }
    }
}
