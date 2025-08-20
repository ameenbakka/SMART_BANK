using EMPLOYEE_AUDIT_LOGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE_AUDIT_LOGS.Application
{
    public interface IEmployeeAuditLogRepository
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<dynamic> GetById(int LogId);
        Task<int> AddAuditLogAsync(EmployeeAuditLog log);
        Task<int> UpdateAuditLogAsync(EmployeeAuditLog log);
        Task<int> DeleteAsync(int LogId);
    }
}
