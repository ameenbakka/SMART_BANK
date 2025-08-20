using ACCOUNT.Application;
using EMPLOYEE_AUDIT_LOGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE_AUDIT_LOGS.Application
{
    public interface IEmployeeAuditLogService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int logId);
        Task<ApiResponse<int>> AddAsync(EmployeeAuditLog log);
        Task<ApiResponse<int>> UpdateAsync(EmployeeAuditLog log);
        Task<ApiResponse<int>> DeleteAsync(int logId);
    }
}
