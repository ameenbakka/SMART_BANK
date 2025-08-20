using DIGITAL_SESSIONS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIGITAL_SESSIONS.Application
{
    public interface IDigitalSessionRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int sessionId);
        Task<int> AddAsync(DigitalSession session);
        Task<int> UpdateAsync(DigitalSession session);
        Task<int> DeleteAsync(int sessionId);
    }
}
