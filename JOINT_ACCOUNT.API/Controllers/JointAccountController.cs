using JOINT_ACCOUNT.Application;
using JOINT_ACCOUNT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JOINT_ACCOUNT.API.Controllers
{
    [Route("api/JointAccount")]
    [ApiController]
    public class JointAccountController : ControllerBase
    {
        private readonly IJointAccountService _jointAccountService;
        public JointAccountController(IJointAccountService jointAccountService)
        {
            _jointAccountService = jointAccountService;
        }

        [HttpGet("GetAllJointAccount")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jointAccountService.GetAllAsync();
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
        [HttpGet("GetByJointAccountId")]
        public async Task<IActionResult> GetbyId(int JointAccountId)
        {
            var result = await _jointAccountService.GetByIdAsync(JointAccountId);
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
                return BadRequest(result.Message);
            }
        }

        [HttpPost("AddJointAccount")]
        public async Task<IActionResult> Add(JointAccount account)
        {
            var result = await _jointAccountService.AddAsync(account);
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
                return BadRequest(result.Message);
            }
        }

        [HttpPatch("UpdateJointAccount")]
        public async Task<IActionResult> Update(JointAccount account)
        {
            var result = await _jointAccountService.UpdateAsync(account);
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
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteJointAccount")]
        public async Task<IActionResult> Delete(int JointAccountId)
        {
            var result = await _jointAccountService.DeleteAsync(JointAccountId);
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
                return BadRequest(result.Message);
            }
        }
    }
}
