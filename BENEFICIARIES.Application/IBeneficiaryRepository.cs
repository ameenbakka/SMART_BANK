using BENEFICIARIES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENEFICIARIES.Application
{
    public interface IBeneficiaryRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int beneficiaryId);
        Task<int> AddAsync(Beneficiary beneficiary);
        Task<int> UpdateAsync(Beneficiary beneficiary);
        Task<int> DeleteAsync(int beneficiaryId);
    }
}
