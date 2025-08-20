using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using TRANSACTION.Application;
using TRANSACTION.Domain;

namespace TRANSACTION.Infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _db;
        public TransactionRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("defaultconnection"));
        }
        public async Task<int> AddTransactionAsync(Transactions transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "INSERT");
            parameters.Add("@UserId", transaction.UserId);
            parameters.Add("@BeneficiaryId", transaction.BeneficiaryId);
            parameters.Add("@RemittanceId", transaction.RemittanceId);
            parameters.Add("@IncomingTransferId", transaction.IncomingTransferId);
            parameters.Add("@FromAccountId", transaction.FromAccountId);
            parameters.Add("@ToAccountId", transaction.ToAccountId);
            parameters.Add("@FromAccountNumber", transaction.FromAccountNumber);
            parameters.Add("@ToAccountNumber", transaction.ToAccountNumber);     
            parameters.Add("@Amount", transaction.Amount);
            parameters.Add("@TransactionType", transaction.TransactionType);
            parameters.Add("@TransactionMethod", transaction.TransactionMethod);
            parameters.Add("@TransactionStatus", transaction.TransactionStatus);
            parameters.Add("@Description", transaction.Description);
            parameters.Add("@AttemptCount", transaction.AttemptCount);
            parameters.Add("@Reversed", transaction.Reversed);
            parameters.Add("@FraudFlag", transaction.FraudFlag);
            parameters.Add("@IsDelete", transaction.IsDelete);
            parameters.Add("@DeviceId", transaction.DeviceId);
            parameters.Add("@Latitude", transaction.Latitude);
            parameters.Add("@Longitude", transaction.Longitude);
            parameters.Add("@CreatedBy", transaction.CreatedBy);
            parameters.Add("@UpdatedBy", transaction.UpdatedBy);
            parameters.Add("@CreatedAt", transaction.CreatedAt);
            parameters.Add("@UpdatedAt", transaction.UpdatedAt);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Transaction]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateTransactionAsync(Transactions transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@TransactionId", transaction.TransactionId);
            parameters.Add("@UserId", transaction.UserId);
            parameters.Add("@BeneficiaryId", transaction.BeneficiaryId);
            parameters.Add("@RemittanceId", transaction.RemittanceId);
            parameters.Add("@IncomingTransferId", transaction.IncomingTransferId);
            parameters.Add("@FromAccountId", transaction.FromAccountId);
            parameters.Add("@ToAccountId", transaction.ToAccountId);
            parameters.Add("@FromAccountNumber", transaction.FromAccountNumber); 
            parameters.Add("@ToAccountNumber", transaction.ToAccountNumber);
            parameters.Add("@Amount", transaction.Amount);
            parameters.Add("@TransactionType", transaction.TransactionType);
            parameters.Add("@TransactionMethod", transaction.TransactionMethod);
            parameters.Add("@TransactionStatus", transaction.TransactionStatus);
            parameters.Add("@Description", transaction.Description);
            parameters.Add("@AttemptCount", transaction.AttemptCount);
            parameters.Add("@Reversed", transaction.Reversed);
            parameters.Add("@FraudFlag", transaction.FraudFlag);
            parameters.Add("@IsDelete", transaction.IsDelete);
            parameters.Add("@DeviceId", transaction.DeviceId);
            parameters.Add("@Latitude", transaction.Latitude);
            parameters.Add("@Longitude", transaction.Longitude);
            parameters.Add("@CreatedBy", transaction.CreatedBy);
            parameters.Add("@UpdatedBy", transaction.UpdatedBy);
            parameters.Add("@CreatedAt", transaction.CreatedAt);
            parameters.Add("@UpdatedAt", transaction.UpdatedAt);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Transaction]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteTransactionAsync(int TransactionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@TransactionId", @TransactionId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Transaction]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
