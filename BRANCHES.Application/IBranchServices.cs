using ACCOUNT.Application;
using BRANCHES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANCHES.Application
{
    public interface IBranchServices
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllBranchesAync();
        Task<ApiResponse<dynamic>> GetBYBranchIdAsync(int BranchId);
        Task<ApiResponse<int>> AddBranchasync(Branch branch);
        Task<ApiResponse<int>> UpdateBranchAsync(Branch branch);
        Task<ApiResponse<int>> DeleteBranchAsync(int BranchId);

    }
}
