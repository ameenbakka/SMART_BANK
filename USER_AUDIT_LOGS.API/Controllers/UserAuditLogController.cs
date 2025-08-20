using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USER_AUDIT_LOGS.Application;
using USER_AUDIT_LOGS.Domain;

namespace USER_AUDIT_LOGS.API.Controllers
{
    [Route("api/UserAuditLog")]
    [ApiController]
    public class UserAuditLogController : ControllerBase
    {
        private readonly IUserAuditLogsService _service;
        public UserAuditLogController(IUserAuditLogsService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int logId)
        {
            var result = await _service.GetByIdAsync(logId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserAuditLog log)
        {
            var result = await _service.AddAsync(log);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(UserAuditLog log)
        {
            var result = await _service.UpdateAsync(log);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int logId)
        {
            var result = await _service.DeleteAsync(logId);
            return StatusCode(result.StatusCode, result);
        }
    }
}
