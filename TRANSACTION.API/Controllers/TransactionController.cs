using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRANSACTION.Application;
using TRANSACTION.Domain;

namespace TRANSACTION.API.Controllers
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;
        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> Add(Transactions transactions)
        {
            var result = await _transactionServices.AddTransaction(transactions);
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
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }
        [HttpPatch("UpdateTransaction")]
        public async Task<IActionResult> Update(Transactions transactions)
        {
            var result = await _transactionServices.UpdateTransaction(transactions);
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
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }
        [HttpDelete("DeleteTransaction")]
        public async Task<IActionResult> Delete(int TransactionId)
        {
            var result = await _transactionServices.DeleteTransaction(TransactionId);
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
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }
    }
}
