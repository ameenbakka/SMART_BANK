using REMITTANCE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMITTANCE.Application
{
    public interface IRemittanceRepository
    {
        Task<int> AddAsync(Remittance remittance);
        Task<int> UpdateAsync(Remittance remittance);
        Task<int> DeleteAsync(int remittanceId);
        Task<dynamic> GetByIdAsync(int remittanceId);
        Task<IEnumerable<dynamic>> GetAllAsync();
    }
}
