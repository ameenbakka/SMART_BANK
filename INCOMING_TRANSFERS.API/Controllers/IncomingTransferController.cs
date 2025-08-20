using INCOMING_TRANSFERS.Application;
using INCOMING_TRANSFERS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INCOMING_TRANSFERS.API.Controllers
{
    [Route("api/IncomingTransfer")]
    [ApiController]
    public class IncomingTransferController : ControllerBase
    {
        private readonly IIncomingTransferService _incomingTransfer;
        public IncomingTransferController(IIncomingTransferService incomingTransfer)
        {
            _incomingTransfer = incomingTransfer;
        }
        [HttpGet("GetIncomingTransferById")]
        public async Task<IActionResult> GetById(int IncomingTransferId, int ReceiverUserId)
        {
            var result = await _incomingTransfer.GetIncomingTransferById(IncomingTransferId, ReceiverUserId);
            if(result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if(result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if(result.StatusCode == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("AddIncomingTransfer")]
        public async Task<IActionResult> Add(IncomingTransfer transfer)
        {
            var result = await _incomingTransfer.AddIncomingTransfer(transfer);
            if(result.StatusCode == 201)
            {
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else if(result.StatusCode == 400)
            {
                return BadRequest(result);
            }
            else if (result.StatusCode == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPatch("UpdateIncomingTransfer")]
        public async Task<IActionResult> Update(IncomingTransfer transfer)
        {
            var result = await _incomingTransfer.UpdateIncomingTransfer(transfer);
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
        [HttpDelete("DeleteIncomingTransfer")]
        public async Task<IActionResult> Delete(int IncomingTransferId)
        {
            var result = await _incomingTransfer.DeleteIncomingTransfer(IncomingTransferId);
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
                return BadRequest(result);
            }
        }
    }
}
