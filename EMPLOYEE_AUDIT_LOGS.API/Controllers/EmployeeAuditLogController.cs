using EMPLOYEE_AUDIT_LOGS.Application;
using EMPLOYEE_AUDIT_LOGS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEE_AUDIT_LOGS.API.Controllers
{
    [Route("api/EmployeeAuditLog")]
    [ApiController]
    public class EmployeeAuditLogController : ControllerBase
    {
        private readonly IEmployeeAuditLogService _service;
        public EmployeeAuditLogController(IEmployeeAuditLogService log)
        {
            _service = log;
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
        public async Task<IActionResult> Add(EmployeeAuditLog log)
        {
            var result = await _service.AddAsync(log);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(EmployeeAuditLog log)
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


