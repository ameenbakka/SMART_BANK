using BENEFICIARIES.Application;
using BENEFICIARIES.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BENEFICIARIES.API.Controllers
{
    [Route("api/Beneficiary")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBenificiaryService _beneficiary;
        public BeneficiaryController(IBenificiaryService benificiary)
        {
            _beneficiary = benificiary;
        }

        [HttpGet("GetAllBeneficiary")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _beneficiary.GetAllAsync();
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

        [HttpGet("GetByBeneficiaryId")]
        public async Task<IActionResult> GetbyId(int BeneficiaryId)
        {
            var result = await _beneficiary.GetByIdAsync(BeneficiaryId);
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

        [HttpPost("AddBeneficiary")]
        public async Task<IActionResult> Addbranch(Beneficiary beneficiary)
        {
            var result = await _beneficiary.AddAsync(beneficiary);
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

        [HttpPatch("UpdateBeneficiary")]
        public async Task<IActionResult> UpdateBranch(Beneficiary beneficiary)
        {
            var result = await _beneficiary.UpdateAsync(beneficiary);
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

        [HttpDelete("DeleteBeneficiary")]
        public async Task<IActionResult> DeleteBranch(int BeneficiaryId)
        {
            var result = await _beneficiary.DeleteAsync(BeneficiaryId);
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
