using ACCOUNT.Application;
using DEPOSIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOSIT.Application
{
    public interface IDepositService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllDepositsAsync();
        Task<ApiResponse<dynamic>> GetByDepositIdAsync(int depositId);
        Task<ApiResponse<int>> AddDepositAsync(Deposit deposit);
        Task<ApiResponse<int>> UpdateDepositAsync(Deposit deposit);
        Task<ApiResponse<int>> DeleteDepositAsync(int depositId);
    }
}
