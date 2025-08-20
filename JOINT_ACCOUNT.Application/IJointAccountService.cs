using ACCOUNT.Application;
using JOINT_ACCOUNT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOINT_ACCOUNT.Application
{
    public interface IJointAccountService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<dynamic>> GetByIdAsync(int jointaccountId);
        Task<ApiResponse<int>> AddAsync(JointAccount account);
        Task<ApiResponse<int>> UpdateAsync(JointAccount account);
        Task<ApiResponse<int>> DeleteAsync(int JointaccountId);
    }
}
