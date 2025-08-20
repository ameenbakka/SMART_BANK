using ACCOUNT.Application;
using ANALYTICS_LOGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANALYTICS_LOGS.Application
{
    public interface IAnalyticsLogService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAnalyticsLogsAsync();
        Task<ApiResponse<dynamic>> GetAnalyticsLogByIdAsync(int logId);
        Task<ApiResponse<int>> AddAnalyticsLogAsync(AnalyticsLog log);
        Task<ApiResponse<int>> UpdateAnalyticsLogAsync(AnalyticsLog log);
        Task<ApiResponse<int>> DeleteAnalyticsLogAsync(int logId);
    }
}
