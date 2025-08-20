using ACCOUNT.Application;
using ANALYTICS_LOGS.Domain;
using System.Data.SqlClient;

namespace ANALYTICS_LOGS.Application
{
    public class AnalyticsLogService : IAnalyticsLogService
    {
        private readonly IAnalyticsLogRepository _analyticsLogsRepository;
        public AnalyticsLogService(IAnalyticsLogRepository repository)
        {
            _analyticsLogsRepository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAnalyticsLogsAsync()
        {
            try
            {
                var result = await _analyticsLogsRepository.GetAllAsync();

                return new ApiResponse<IEnumerable<dynamic>>(200, "Analytics logs retrieved successfully.", result);
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

        public async Task<ApiResponse<dynamic>> GetAnalyticsLogByIdAsync(int logId)
        {
            try
            {
                var result = await _analyticsLogsRepository.GetByIdAsync(logId);

                if (result != null)
                    return new ApiResponse<dynamic>(200, "Analytics log retrieved successfully.", result);

                return new ApiResponse<dynamic>(404, "Analytics log not found.");
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

        public async Task<ApiResponse<int>> AddAnalyticsLogAsync(AnalyticsLog log)
        {
            try
            {
                var result = await _analyticsLogsRepository.AddAsync(log);

                if (result > 0)
                    return new ApiResponse<int>(201, $"Analytics log created successfully. Rows affected: {result}");

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

        public async Task<ApiResponse<int>> UpdateAnalyticsLogAsync(AnalyticsLog log)
        {
            try
            {
                var result = await _analyticsLogsRepository.UpdateAsync(log);

                if (result > 0)
                    return new ApiResponse<int>(200, $"Analytics log updated successfully. Rows affected: {result}");

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

        public async Task<ApiResponse<int>> DeleteAnalyticsLogAsync(int logId)
        {
            try
            {
                var result = await _analyticsLogsRepository.DeleteAsync(logId);

                if (result > 0)
                    return new ApiResponse<int>(200, $"Analytics log deleted successfully. Rows affected: {result}");

                return new ApiResponse<int>(404, "Not found");
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
