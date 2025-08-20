using ACCOUNT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNT.Application
{
    public interface IAccountRepository
    {
        Task<IEnumerable<dynamic>> GetAllAccountsAsync();
        Task<dynamic> GetByAccountNumberAsync(long AccountNumber);
        Task<int> AddAccountAsync(Account account);
        Task<int> UpdateAccountAsync(Account account);
        Task<int> DeleteAccountAsync(long AccountNumber);
    }
}
