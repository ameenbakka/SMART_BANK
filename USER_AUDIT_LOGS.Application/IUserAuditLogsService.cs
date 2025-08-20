using ACCOUNT.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_AUDIT_LOGS.Domain;

namespace USER_AUDIT_LOGS.Application
{
    public interface IUserAuditLogsService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int logId);
        Task<ApiResponse<int>> AddAsync(UserAuditLog log);
        Task<ApiResponse<int>> UpdateAsync(UserAuditLog log);
        Task<ApiResponse<int>> DeleteAsync(int logId);
    }
}
