using DIGITAL_SESSIONS.Application;
using DIGITAL_SESSIONS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIGITAL_SESSIONS.API.Controllers
{
    [Route("api/DigitalSession")]
    [ApiController]
    public class DigitalSessionController : ControllerBase
    {
        private readonly IDigitalSessionService _service;
        public DigitalSessionController(IDigitalSessionService Service)
        {
            _service = Service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int sessionId)
        {
            var result = await _service.GetByIdAsync(sessionId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(DigitalSession session)
        {
            var result = await _service.AddAsync(session);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(DigitalSession session)
        {
            var result = await _service.UpdateAsync(session);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int sessionId)
        {
            var result = await _service.DeleteAsync(sessionId);
            return StatusCode(result.StatusCode, result);
        }
    }

}

