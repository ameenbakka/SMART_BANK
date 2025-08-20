using ACCOUNT.Application;
using ACCOUNT.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ACCOUNT.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _db;
        public AccountRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }
        public async Task<IEnumerable<dynamic>> GetAllAccountsAsync()
        {
            var parameter = new DynamicParameters();
            parameter.Add("@FLAG", "GETALL");

            return await _db.QueryAsync<Account>
                ("[dbo].[SP_ACCOUNT]", parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetByAccountNumberAsync(long AccountNumber)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@FLAG", "GETBYID");
            parameter.Add("@AccountNumber", AccountNumber);

            return  await _db.QueryFirstOrDefaultAsync<Account>
                ("[dbo].[SP_ACCOUNT]", parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddAccountAsync(Account account)
        {
            var parameter = new DynamicParameters();

            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "INSERT");
            parameters.Add("@USERID", account.UserId);
            parameters.Add("@BRANCHID", account.BranchId);
            parameters.Add("@ACCOUNTNUMBER", account.AccountNumber);
            parameters.Add("@ACCOUNTTYPE", account.AccountType);
            parameters.Add("@ACCOUNTSTATUS", account.AccountStatus);
            parameters.Add("@BALANCE", account.Balance);
            parameters.Add("@BRANCHCODE", account.BranchCode);
            parameters.Add("@INTERESTRATE", account.InterestRate);
            parameters.Add("@MINIMUMBALANCE", account.MinimumBalance);
            parameters.Add("@CreatedBy", account.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_ACCOUNT]", parameters, commandType: CommandType.StoredProcedure);
            
        }
        public async Task<int> UpdateAccountAsync(Account account)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FLAG", "UPDATE");
            parameters.Add("@USERID", account.UserId);
            parameters.Add("@BRANCHID", account.BranchId);
            parameters.Add("@ACCOUNTNUMBER", account.AccountNumber);
            parameters.Add("@ACCOUNTTYPE", account.AccountType);
            parameters.Add("@ACCOUNTSTATUS", account.AccountStatus);
            parameters.Add("@BALANCE", account.Balance);
            parameters.Add("@BRANCHCODE", account.BranchCode);
            parameters.Add("@INTERESTRATE", account.InterestRate);
            parameters.Add("@MINIMUMBALANCE", account.MinimumBalance);
            parameters.Add("@UpdatedBy", account.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_ACCOUNT]", parameters, commandType: CommandType.StoredProcedure);
            
        }
        public async Task<int> DeleteAccountAsync(long AccountNumber)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FLAG", "DELETE");
            parameters.Add("@AccountNumber", AccountNumber);

            return await _db.ExecuteAsync
                ("[dbo].[SP_ACCOUNT]", parameters, commandType: CommandType.StoredProcedure);
            
        }
    }
}
