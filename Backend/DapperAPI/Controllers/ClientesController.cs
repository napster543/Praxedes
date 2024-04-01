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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteRepository repo, ILogger<ClientesController> logger)
        {
            _repo = repo;
            _logger = logger ;
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
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            string _result = string.Empty;
            try
            {
                var validator = new ValidationsCliente();
                ValidationResult result = validator.Validate(cliente);
                _result = await _repo.Create(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
            return Ok(_result);            
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente, int id)
        {
            string _result = string.Empty;
            try
            {
                _result = await _repo.Update(cliente, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
            
            return Ok(_result);
        }
        [HttpGet("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var _result = await _repo.Remove(id);
            return Ok(_result);
        }
    }
}
