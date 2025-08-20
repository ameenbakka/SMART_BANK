using ANALYTICS_LOGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALYTICS_LOGS.Application
{
    public interface IAnalyticsLogRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int logId);
        Task<int> AddAsync(AnalyticsLog log);
        Task<int> UpdateAsync(AnalyticsLog log);
        Task<int> DeleteAsync(int logId);
    }
}
