using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOMINEE.Application;
using NOMINEE.Domain;

namespace NOMINEE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomineeController : ControllerBase
    {
        private readonly INomineeService _nomineeService;

        public NomineeController(INomineeService nomineeService)
        {
            _nomineeService = nomineeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _nomineeService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _nomineeService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromForm] Nominee nominee)
        {
            var response = await _nomineeService.AddAsync(nominee);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] Nominee nominee)
        {
            var response = await _nomineeService.UpdateAsync(nominee);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _nomineeService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
