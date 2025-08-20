namespace USER_AUDIT_LOGS.Application
{
    using ACCOUNT.Application;
    using System.Data.SqlClient;
    using USER_AUDIT_LOGS.Application;
    using USER_AUDIT_LOGS.Domain;

    public class UserAuditLogsService : IUserAuditLogsService
    {
        private readonly IUserAuditLogRepository _repository;

        public UserAuditLogsService(IUserAuditLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "User Audit Logs retrieved successfully", result);
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

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int logId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(logId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "User Audit Log retrieved successfully", result);

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

        public async Task<ApiResponse<int>> AddAsync(UserAuditLog log)
        {
            try
            {
                var result = await _repository.AddAsync(log);
                if (result > 0)
                    return new ApiResponse<int>(201, "User Audit Log created successfully", result);

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

        public async Task<ApiResponse<int>> UpdateAsync(UserAuditLog log)
        {
            try
            {
                var result = await _repository.UpdateAsync(log);
                if (result > 0)
                    return new ApiResponse<int>(200, "User Audit Log updated successfully");

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

        public async Task<ApiResponse<int>> DeleteAsync(int logId)
        {
            try
            {
                var result = await _repository.DeleteAsync(logId);
                if (result > 0)
                    return new ApiResponse<int>(200, "User Audit Log deleted successfully");

                return new ApiResponse<int>(404, "Not Found");
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
