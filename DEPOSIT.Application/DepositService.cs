using ACCOUNT.Application;
using DEPOSIT.Domain;
using System.Data.SqlClient;

namespace DEPOSIT.Application
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _depositRepository;
        public DepositService(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllDepositsAsync()
        {
            try
            {
                var result = await _depositRepository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Deposits Retrieved Successfully", result);
            }
            catch (SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<dynamic>> GetByDepositIdAsync(int depositId)
        {
            try
            {
                var result = await _depositRepository.GetByIdAsync(depositId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Deposit Retrieved Successfully", result);

                return new ApiResponse<dynamic>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<dynamic>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> AddDepositAsync(Deposit deposit)
        {
            try
            {
                var result = await _depositRepository.AddAsync(deposit);
                if (result > 0)
                    return new ApiResponse<int>(201, "Deposit Created Successfully", result);

                return new ApiResponse<int>(400, "Bad Request");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateDepositAsync(Deposit deposit)
        {
            try
            {
                var result = await _depositRepository.UpdateAsync(deposit);
                if (result > 0)
                    return new ApiResponse<int>(200, "Updated Successfully");

                return new ApiResponse<int>(204, "No Content");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteDepositAsync(int depositId)
        {
            try
            {
                var result = await _depositRepository.DeleteAsync(depositId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Deleted Successfully");

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error: {ex.Message}");
            }
        }
    }
}
