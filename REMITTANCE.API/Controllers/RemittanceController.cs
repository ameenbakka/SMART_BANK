using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMITTANCE.Application;
using REMITTANCE.Domain;

namespace REMITTANCE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemittanceController : ControllerBase
    {
        private readonly IRemittanceService _remittanceService;

        public RemittanceController(IRemittanceService remittanceService)
        {
            _remittanceService = remittanceService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _remittanceService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _remittanceService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Remittance remittance)
        {
            var response = await _remittanceService.AddAsync(remittance);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Remittance remittance)
        {
            var response = await _remittanceService.UpdateAsync(remittance);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _remittanceService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
