using ACCOUNT.Application;
using NOMINEE.Domain;
using System.Data.SqlClient;

namespace NOMINEE.Application
{
    public class NomineeService : INomineeService
    {
        private readonly INomineeRepository _repository;

        public NomineeService(INomineeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Nominees retrieved successfully", result);
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

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int nomineeId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(nomineeId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Nominee retrieved successfully", result);

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

        public async Task<ApiResponse<int>> AddAsync(Nominee nominee)
        {
            try
            {
                var result = await _repository.AddAsync(nominee);
                if (result > 0)
                    return new ApiResponse<int>(201, "Nominee created successfully", result);

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

        public async Task<ApiResponse<int>> UpdateAsync(Nominee nominee)
        {
            try
            {
                var result = await _repository.UpdateAsync(nominee);
                if (result > 0)
                    return new ApiResponse<int>(200, "Nominee updated successfully");

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
        public async Task<ApiResponse<int>> DeleteAsync(int nomineeId)
        {
            try
            {
                var result = await _repository.DeleteAsync(nomineeId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Nominee retrieved successfully", result);

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
