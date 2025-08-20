using Dapper;
using DEPOSIT.Application;
using DEPOSIT.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DEPOSIT.Infrastructure
{
    public class DepositRepository : IDepositRepository
    {
        private readonly IDbConnection _db;
        public DepositRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }
        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETALL");

            return await _db.QueryAsync<Deposit>
                ("[dbo].[SP_DepositAccounts]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int depositId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETBYID");
            parameters.Add("@DepositId", depositId);

            return await _db.QueryFirstOrDefaultAsync<Deposit>
                ("[dbo].[SP_DepositAccounts]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(Deposit deposit)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "INSERT");
            parameters.Add("@UserId", deposit.UserId);
            parameters.Add("@AccountId", deposit.AccountId);
            parameters.Add("@DepositType", deposit.DepositType.ToString());
            parameters.Add("@Amount", deposit.Amount);
            parameters.Add("@InterestRate", deposit.InterestRate);
            parameters.Add("@DepositTenure", deposit.DepositTenure);
            parameters.Add("@InterestFrequency", deposit.InterestFrequency.ToString());
            parameters.Add("@StartDate", deposit.StartDate);
            parameters.Add("@MaturityDate", deposit.MaturityDate);
            parameters.Add("@Status", deposit.Status.ToString());
            parameters.Add("@AutoRenew", deposit.AutoRenew);
            parameters.Add("@PrematureWithdraw", deposit.PrematureWithdraw);
            parameters.Add("@CreatedBy", deposit.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DepositAccounts]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Deposit deposit)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "UPDATE");
            parameters.Add("@DepositId", deposit.DepositId);
            parameters.Add("@AccountId", deposit.AccountId);
            parameters.Add("@DepositType", deposit.DepositType.ToString());
            parameters.Add("@Amount", deposit.Amount);
            parameters.Add("@InterestRate", deposit.InterestRate);
            parameters.Add("@DepositTenure", deposit.DepositTenure);
            parameters.Add("@InterestFrequency", deposit.InterestFrequency.ToString());
            parameters.Add("@StartDate", deposit.StartDate);
            parameters.Add("@MaturityDate", deposit.MaturityDate);
            parameters.Add("@Status", deposit.Status.ToString());
            parameters.Add("@AutoRenew", deposit.AutoRenew);
            parameters.Add("@PrematureWithdraw", deposit.PrematureWithdraw);
            parameters.Add("@UpdatedBy", deposit.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DepositAccounts]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int depositId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "DELETE");
            parameters.Add("@DepositId", depositId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DepositAccounts]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
