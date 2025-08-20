using ACCOUNT.Application;
using ACCOUNT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNT.Api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _accountService.GetAllAccountsAsync();
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

        [HttpGet("GetByAccountNumber")]
        public async Task<IActionResult> GetAll(long AccountNumber)
        {
            var result = await _accountService.GetByAccountNumberAsync(AccountNumber);

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

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromForm] Account account)
        {
            var result = await _accountService.AddAccountAsync(account);

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

        [HttpPatch("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromForm] Account account)
        {
            var result = await _accountService.UpdateAccountAsync(account);

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

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(long AccountNumber)
        {
            var result = await _accountService.DeleteAccountAsync(AccountNumber);

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
