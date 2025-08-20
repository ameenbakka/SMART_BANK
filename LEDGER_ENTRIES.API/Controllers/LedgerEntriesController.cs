using LEDGER_ENTRIES.Applicaton;
using LEDGER_ENTRIES.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LEDGER_ENTRIES.API.Controllers
{
    [Route("api/LedgerEntries")]
    [ApiController]
    public class LedgerEntriesController : ControllerBase
    {
        private readonly ILedgerEntriesService _service;

        public LedgerEntriesController(ILedgerEntriesService service)
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
        public async Task<IActionResult> GetById(int ledgerEntryId)
        {
            var result = await _service.GetByIdAsync(ledgerEntryId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LedgerEntry entry)
        {
            var result = await _service.AddAsync(entry);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(LedgerEntry entry)
        {
            var result = await _service.UpdateAsync(entry);
            return StatusCode(result.StatusCode, result);
        }
    }
}
