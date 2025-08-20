using ACCOUNT.Application;
using REMITTANCE.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMITTANCE.Application
{
    public class RemittanceService : IRemittanceService
    {
        private readonly IRemittanceRepository _repository;

        public RemittanceService(IRemittanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Remittances retrieved successfully", result);
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

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int remittanceId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(remittanceId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Remittance retrieved successfully", result);

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

        public async Task<ApiResponse<int>> AddAsync(Remittance remittance)
        {
            try
            {
                var result = await _repository.AddAsync(remittance);
                if (result > 0)
                    return new ApiResponse<int>(201, "Remittance created successfully", result);

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

        public async Task<ApiResponse<int>> UpdateAsync(Remittance remittance)
        {
            try
            {
                var result = await _repository.UpdateAsync(remittance);
                if (result > 0)
                    return new ApiResponse<int>(200, "Remittance updated successfully");

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
        public async Task<ApiResponse<int>> DeleteAsync(int remittanceId)
        {
            try
            {
                var result = await _repository.DeleteAsync(remittanceId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Remittance Deleted successfully", result);

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
