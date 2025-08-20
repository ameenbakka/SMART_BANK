using ACCOUNT.Application;
using DIGITAL_SESSIONS.Domain;
using System.Data.SqlClient;

namespace DIGITAL_SESSIONS.Application
{
    public class DigitalSessionService : IDigitalSessionService
    {
        private readonly IDigitalSessionRepository _repository;

        public DigitalSessionService(IDigitalSessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Digital Sessions retrieved successfully", result);
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

        public async Task<ApiResponse<dynamic>> GetByIdAsync(int sessionId)
        {
            try
            {
                var result = await _repository.GetByIdAsync(sessionId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Digital Session retrieved successfully", result);

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

        public async Task<ApiResponse<int>> AddAsync(DigitalSession session)
        {
            try
            {
                var result = await _repository.AddAsync(session);
                if (result > 0)
                    return new ApiResponse<int>(201, "Digital Session created successfully", result);

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

        public async Task<ApiResponse<int>> UpdateAsync(DigitalSession session)
        {
            try
            {
                var result = await _repository.UpdateAsync(session);
                if (result > 0)
                    return new ApiResponse<int>(200, "Digital Session updated successfully");

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

        public async Task<ApiResponse<int>> DeleteAsync(int sessionId)
        {
            try
            {
                var result = await _repository.DeleteAsync(sessionId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Digital Session deleted successfully");

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
