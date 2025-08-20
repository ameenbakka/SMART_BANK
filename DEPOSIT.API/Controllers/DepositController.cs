using DEPOSIT.Application;
using DEPOSIT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEPOSIT.API.Controllers
{
    [Route("api/Deposit")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _depositService;
        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpGet("GetAllDeposits")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _depositService.GetAllDepositsAsync();
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByDepositId")]
        public async Task<IActionResult> GetById(int depositId)
        {
            var result = await _depositService.GetByDepositIdAsync(depositId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpPost("AddDeposit")]
        public async Task<IActionResult> AddDeposit(Deposit deposit)
        {
            var result = await _depositService.AddDepositAsync(deposit);
            if (result.StatusCode == 201)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 400)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpPatch("UpdateDeposit")]
        public async Task<IActionResult> UpdateDeposit(Deposit deposit)
        {
            var result = await _depositService.UpdateDepositAsync(deposit);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 204)
            {
                return StatusCode(StatusCodes.Status204NoContent, result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpDelete("DeleteDeposit")]
        public async Task<IActionResult> DeleteDeposit(int depositId)
        {
            var result = await _depositService.DeleteDepositAsync(depositId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }
    }
}
