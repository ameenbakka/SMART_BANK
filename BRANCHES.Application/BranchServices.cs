using ACCOUNT.Application;
using BRANCHES.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANCHES.Application
{
    public class BranchServices : IBranchServices
    {
        private readonly IBranchesRepository _branchesRepository;
        public BranchServices(IBranchesRepository branchesRepository)
        {
            _branchesRepository = branchesRepository;
        }
        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllBranchesAync()
        {
            try
            {
                var result = await _branchesRepository.GetAllBranchesAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Braches Retrives Successfully", result);
            }
            catch(SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $" SQL Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>> ( 500, $" Unexpected Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<dynamic>> GetBYBranchIdAsync(int BranchId)
        {
            try
            {
                var result = await _branchesRepository.GetByBranchIdAsync(BranchId);
                if (result != null) 
                    return new ApiResponse<dynamic>(200, "Branch Retrive Successfully", result);

                return new ApiResponse<dynamic>(404, "Not Found");
            }
            catch(SqlException ex)
            {
                return new ApiResponse<dynamic> (500, $" SQL Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                return new ApiResponse<dynamic>(500, $" Unexpected Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> AddBranchasync(Branch branch)
        {
            try
            {
                var result = await _branchesRepository.AddBranchAsync(branch);
                if (result > 0)
                    return new ApiResponse<int>(201, "Branch Created SuccessFully", result);

                return new ApiResponse<int>(400, "Bad Request");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $" Unexpected Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> UpdateBranchAsync(Branch branch)
        {
            try
            {
                var result = await _branchesRepository.UpdateBranchAsync(branch);
                if (result > 0)
                    return new ApiResponse<int>(200, "Updated Successfully");

                return new ApiResponse<int>(204, "No Content");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $" Unexpected Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> DeleteBranchAsync(int BranchId)
        {
            try
            {
                var result = await _branchesRepository.DeleteBranchesAsync(BranchId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Deleted Successfully");

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $" Unexpected Error: {ex.Message}");
            }
        }
    }
}
