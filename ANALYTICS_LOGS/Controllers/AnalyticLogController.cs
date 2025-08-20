using ANALYTICS_LOGS.Application;
using ANALYTICS_LOGS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANALYTICS_LOGS.API.Controllers
{
    [Route("api/AnalyticsLogs")]
    [ApiController]
    public class AnalyticLogController : ControllerBase
    {
        private readonly IAnalyticsLogService _analyticsLogsService;
        public AnalyticLogController(IAnalyticsLogService analyticsLogService)
        {
            _analyticsLogsService = analyticsLogService;
        }

        [HttpGet("GetAllAnalyticsLog")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _analyticsLogsService.GetAllAnalyticsLogsAsync();
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

        [HttpGet("GetByAnalyticsLogId")]
        public async Task<IActionResult> GetById(int logId)
        {
            var result = await _analyticsLogsService.GetAnalyticsLogByIdAsync(logId);
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

        [HttpPost("AddAnalyticsLog")]
        public async Task<IActionResult> Add(AnalyticsLog log)
        {
            var result = await _analyticsLogsService.AddAnalyticsLogAsync(log);
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

        [HttpPatch("UpdateAnalyticsLog")]
        public async Task<IActionResult> Update(AnalyticsLog log)
        {
            var result = await _analyticsLogsService.UpdateAnalyticsLogAsync(log);
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

        [HttpDelete("DeleteAnalyticsLog")]
        public async Task<IActionResult> Delete(int logId)
        {
            var result = await _analyticsLogsService.DeleteAnalyticsLogAsync(logId);
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
