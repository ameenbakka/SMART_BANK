using ACCOUNT.Application;
using JOINT_ACCOUNT.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOINT_ACCOUNT.Application
{
    public class JointAccountService : IJointAccountService
    {
        private readonly IJointAccountRepository _jointAccountRepository;
        public JointAccountService(IJointAccountRepository jointAccountRepository)
        {
            _jointAccountRepository = jointAccountRepository;
        }
        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _jointAccountRepository.GetAllJointAccountsAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Retrived Successfully", result);
            }
            catch (SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<dynamic>> GetByIdAsync(int jointaccountId)
        {
            try
            {
                var result = await _jointAccountRepository.GetJointAccountByIdAsync(jointaccountId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Retrived Successfully", result);

                return new ApiResponse<dynamic>(404, "Not found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<dynamic>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> AddAsync(JointAccount account)
        {
            try
            {
                var result = await _jointAccountRepository.AddJointAccountAsync(account);
                if (result > 0)
                    return new ApiResponse<int>(201, "Created Successfully", result);

                return new ApiResponse<int>(400, "Bad Requset");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> UpdateAsync(JointAccount account)
        {
            try
            {
                var result = await _jointAccountRepository.UpdateJointAccountAsync(account);
                if (result > 0)
                    return new ApiResponse<int>(200, "Updated Successfully", result);

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> DeleteAsync(int JointaccountId)
        {
            try
            {
                var result = await _jointAccountRepository.DeleteJointAccountAsync(JointaccountId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Employee Deleted Successfully", result);

                return new ApiResponse<int>(404, "Not found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
    }
}
