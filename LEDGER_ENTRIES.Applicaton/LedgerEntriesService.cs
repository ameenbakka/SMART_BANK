using ACCOUNT.Application;
using LEDGER_ENTRIES.Domain;
using System.Data.SqlClient;

namespace LEDGER_ENTRIES.Applicaton
{
    public class LedgerEntriesService : ILedgerEntriesService
    {
        private readonly ILedgerEntriesRepository _repository;

        public LedgerEntriesService(ILedgerEntriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Ledger entries retrieved successfully", result);
            }
            catch (SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int ledgerEntryId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(ledgerEntryId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Ledger entry retrieved successfully", result);

                return new ApiResponse<dynamic>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<dynamic>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> AddAsync(LedgerEntry entry)
        {
            try
            {
                var result = await _repository.AddAsync(entry);
                if (result > 0)
                    return new ApiResponse<int>(201, "Ledger entry created successfully", result);

                return new ApiResponse<int>(400, "Bad Request");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateAsync(LedgerEntry entry)
        {
            try
            {
                var result = await _repository.UpdateAsync(entry);
                if (result > 0)
                    return new ApiResponse<int>(200, "Ledger entry updated successfully");

                return new ApiResponse<int>(204, "No Content");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error: {ex.Message}");
            }
        }
    }
}
