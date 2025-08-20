using LEDGER_ENTRIES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDGER_ENTRIES.Applicaton
{
    public interface ILedgerEntriesRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int ledgerEntryId);
        Task<int> AddAsync(LedgerEntry entry);
        Task<int> UpdateAsync(LedgerEntry entry);

    }
}
