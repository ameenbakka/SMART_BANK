using Dapper;
using LEDGER_ENTRIES.Applicaton;
using LEDGER_ENTRIES.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LEDGER_ENTRIES.Infrastructure
{
    public class LedgerEntriesRepository : ILedgerEntriesRepository
    {
        private readonly IDbConnection _db;

        public LedgerEntriesRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETALL");

            return await _db.QueryAsync<LedgerEntry>
                ("SP_LedgerEntries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int ledgerEntryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETBYID");
            parameters.Add("@LedgerEntryId", ledgerEntryId);

            return await _db.QueryFirstOrDefaultAsync<LedgerEntry>
                ("SP_LedgerEntries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(LedgerEntry entry)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "INSERT");
            parameters.Add("@AccountId", entry.AccountId);
            parameters.Add("@TransactionId", entry.TransactionId);
            parameters.Add("@EntryType", entry.EntryType);
            parameters.Add("@Amount", entry.Amount);
            parameters.Add("@Balance", entry.Balance);
            parameters.Add("@Description", entry.Description);
            parameters.Add("@Reconciled", entry.Reconciled);
            parameters.Add("@ReconciliationDate", entry.ReconciliationDate);
            parameters.Add("@CreatedBy", entry.CreatedBy);

            return await _db.ExecuteAsync
                ("SP_LedgerEntries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(LedgerEntry entry)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "UPDATE");
            parameters.Add("@LedgerEntryId", entry.LedgerEntryId);
            parameters.Add("@EntryType", entry.EntryType);
            parameters.Add("@Amount", entry.Amount);
            parameters.Add("@Balance", entry.Balance);
            parameters.Add("@Description", entry.Description);
            parameters.Add("@Reconciled", entry.Reconciled);
            parameters.Add("@ReconciliationDate", entry.ReconciliationDate);
            parameters.Add("@UpdatedBy", entry.UpdatedBy);

            return await _db.ExecuteAsync
                ("SP_LedgerEntries", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
