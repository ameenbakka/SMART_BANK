using ACCOUNT.Application;
using LEDGER_ENTRIES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDGER_ENTRIES.Applicaton
{
    public interface ILedgerEntriesService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int ledgerEntryId);
        Task<ApiResponse<int>> AddAsync(LedgerEntry entry);
        Task<ApiResponse<int>> UpdateAsync(LedgerEntry entry);
    }
}
