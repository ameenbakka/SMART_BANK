using ACCOUNT.Application;
using ACCOUNT.Domain;
using System.Data.SqlClient;
using System.Security.Principal;

namespace Application
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAccountsAsync()
        {
            try
            {
                var result = await _accountRepository.GetAllAccountsAsync();

                return new ApiResponse<IEnumerable<dynamic>>(200, "Accounts retrieved successfully.", result);
            }
            catch (SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $" Unexpected Error: {ex.Message}");
            }

        }
        public async Task<ApiResponse<dynamic>> GetByAccountNumberAsync(long AccountNumber)
        {
            try
            {
                var result = await _accountRepository.GetByAccountNumberAsync(AccountNumber);

                if (result != null)
                    return new ApiResponse<dynamic>(200, "Account retrieved successfully.", result);

                return new ApiResponse<dynamic>(404, "Pls check the account number");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $" SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<dynamic>(500, $" Unexpected Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> AddAccountAsync(Account account)
        {
            try
            {
                var result = await _accountRepository.AddAccountAsync(account);

                if (result > 0 )
                    return new ApiResponse<int>(201, $"Account Created successfully. number of row effected {result}" );

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
        public async Task<ApiResponse<int>> UpdateAccountAsync(Account account)
        {
            try
            {
                var result = await _accountRepository.UpdateAccountAsync(account);

                if (result > 0)
                    return new ApiResponse<int>(200, $"Account Updated successfully. number of row effected {result}");

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
        public async Task<ApiResponse<int>> DeleteAccountAsync(long AccountNumber)
        {
            try
            {
                var result = await _accountRepository.DeleteAccountAsync(AccountNumber);

                if(result > 0)
                    return new ApiResponse<int>(200, $"Account Deleted successfully. Number of row effected {result}");

                return new ApiResponse<int>(404, "Not found");
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
