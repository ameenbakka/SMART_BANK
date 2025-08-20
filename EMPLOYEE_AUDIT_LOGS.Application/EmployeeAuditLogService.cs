using ACCOUNT.Application;
using EMPLOYEE_AUDIT_LOGS.Domain;
using System.Data.SqlClient;

namespace EMPLOYEE_AUDIT_LOGS.Application
{
    public class EmployeeAuditLogService : IEmployeeAuditLogService
    {
        private readonly IEmployeeAuditLogRepository _repository;
        public EmployeeAuditLogService(IEmployeeAuditLogRepository LogRepository)
        {
            _repository = LogRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAll();
                return new ApiResponse<IEnumerable<dynamic>>
                    (200, "Employee Audit Logs retrieved successfully", result);
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
                var result = await _repository.GetById(logId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Employee Audit Log retrieved successfully", result);

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

        public async Task<ApiResponse<int>> AddAsync(EmployeeAuditLog log)
        {
            try
            {
                var result = await _repository.AddAuditLogAsync(log);
                if (result > 0)
                    return new ApiResponse<int>(201, "Employee Audit Log created successfully", result);

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

        public async Task<ApiResponse<int>> UpdateAsync(EmployeeAuditLog log)
        {
            try
            {
                var result = await _repository.UpdateAuditLogAsync(log);
                if (result > 0)
                    return new ApiResponse<int>(200, "Employee Audit Log updated successfully");

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
                    return new ApiResponse<int>(200, "Employee Audit Log deleted successfully");

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
