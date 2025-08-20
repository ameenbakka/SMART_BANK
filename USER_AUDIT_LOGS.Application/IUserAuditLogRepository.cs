using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_AUDIT_LOGS.Domain;

namespace USER_AUDIT_LOGS.Application
{
    public interface IUserAuditLogRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int logId);
        Task<int> AddAsync(UserAuditLog log);
        Task<int> UpdateAsync(UserAuditLog log);
        Task<int> DeleteAsync(int logId);
    }
}
