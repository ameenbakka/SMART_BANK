using ACCOUNT.Application;
using BENEFICIARIES.Domain;
using System.Data.SqlClient;

namespace BENEFICIARIES.Application
{
    public class BeneficiaryService : IBenificiaryService
    {
        private readonly IBeneficiaryRepository _repository;

        public BeneficiaryService(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Beneficiaries retrieved successfully.", result);
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

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int beneficiaryId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(beneficiaryId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Beneficiary retrieved successfully.", result);

                return new ApiResponse<dynamic>(404, "Beneficiary not found.");
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

        public async Task<ApiResponse<int>> AddAsync(Beneficiary beneficiary)
        {
            try
            {
                var result = await _repository.AddAsync(beneficiary);
                if (result > 0)
                    return new ApiResponse<int>(201, $"Beneficiary created successfully. Rows affected: {result}");

                return new ApiResponse<int>(400, "Failed to create beneficiary.");
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

        public async Task<ApiResponse<int>> UpdateAsync(Beneficiary beneficiary)
        {
            try
            {
                var result = await _repository.UpdateAsync(beneficiary);
                if (result > 0)
                    return new ApiResponse<int>(200, $"Beneficiary updated successfully. Rows affected: {result}");

                return new ApiResponse<int>(204, "No content.");
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

        public async Task<ApiResponse<int>> DeleteAsync(int beneficiaryId)
        {
            try
            {
                var result = await _repository.DeleteAsync(beneficiaryId);
                if (result > 0)
                    return new ApiResponse<int>(200, $"Beneficiary deleted successfully. Rows affected: {result}");

                return new ApiResponse<int>(404, "Beneficiary not found.");
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
