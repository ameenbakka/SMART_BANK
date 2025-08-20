using ACCOUNT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNT.Application
{
    public interface IAccountService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAccountsAsync();
        Task<ApiResponse<dynamic>> GetByAccountNumberAsync(long AccountNumber);
        Task<ApiResponse<int>> AddAccountAsync(Account account);
        Task<ApiResponse<int>> UpdateAccountAsync(Account account);
        Task<ApiResponse<int>> DeleteAccountAsync(long AccountNumber);
    }
}
