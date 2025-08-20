using ACCOUNT.Application;
using REMITTANCE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMITTANCE.Application
{
    public interface IRemittanceService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int remittanceId);
        Task<ApiResponse<int>> AddAsync(Remittance remittance);
        Task<ApiResponse<int>> UpdateAsync(Remittance remittance);
        Task<ApiResponse<int>> DeleteAsync(int remittanceId);
    }
}
