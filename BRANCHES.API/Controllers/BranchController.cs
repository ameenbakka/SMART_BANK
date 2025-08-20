using BRANCHES.Application;
using BRANCHES.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BRANCHES.API.Controllers
{
    [Route("api/Branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _branchServices;

        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }

        [HttpGet("GetAllBranches")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _branchServices.GetAllBranchesAync();
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if(result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByBranchId")]
        public async Task<IActionResult> GetbyId(int BranchId)
        {
            var result = await _branchServices.GetBYBranchIdAsync(BranchId);
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

        [HttpPost("AddBranch")]
        public async Task<IActionResult> Addbranch(Branch branch)
        {
            var result = await _branchServices.AddBranchasync(branch);
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

        [HttpPatch("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch(Branch branch)
        {
            var result = await _branchServices.UpdateBranchAsync(branch);
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

        [HttpDelete("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch(int BranchId)
        {
            var result = await _branchServices.DeleteBranchAsync(BranchId);
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
