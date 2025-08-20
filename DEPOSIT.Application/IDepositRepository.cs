using DEPOSIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPOSIT.Application
{
    public interface IDepositRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int depositId);
        Task<int> AddAsync(Deposit deposit);
        Task<int> UpdateAsync(Deposit deposit);
        Task<int> DeleteAsync(int depositId);
    }
}
