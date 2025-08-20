using ACCOUNT.Application;
using NOMINEE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMINEE.Application
{
    public interface INomineeService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int nomineeId);
        Task<ApiResponse<int>> AddAsync(Nominee nominee);
        Task<ApiResponse<int>> UpdateAsync(Nominee nominee);
        Task<ApiResponse<int>> DeleteAsync(int nomineeId);
    }
}
