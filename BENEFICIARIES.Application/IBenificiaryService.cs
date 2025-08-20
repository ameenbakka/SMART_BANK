using ACCOUNT.Application;
using BENEFICIARIES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENEFICIARIES.Application
{
    public interface IBenificiaryService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int beneficiaryId);
        Task<ApiResponse<int>> AddAsync(Beneficiary beneficiary);
        Task<ApiResponse<int>> UpdateAsync(Beneficiary beneficiary);
        Task<ApiResponse<int>> DeleteAsync(int beneficiaryId);
    }
}
