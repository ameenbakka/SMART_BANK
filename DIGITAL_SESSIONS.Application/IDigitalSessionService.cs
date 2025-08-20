using ACCOUNT.Application;
using DIGITAL_SESSIONS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIGITAL_SESSIONS.Application
{
    public interface IDigitalSessionService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int sessionId);
        Task<ApiResponse<int>> AddAsync(DigitalSession session);
        Task<ApiResponse<int>> UpdateAsync(DigitalSession session);
        Task<ApiResponse<int>> DeleteAsync(int sessionId);
    }
}
