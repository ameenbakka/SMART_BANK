
using Dapper;
using Microsoft.Extensions.Configuration;
using REMITTANCE.Application;
using REMITTANCE.Domain;
using System.Data;
using System.Data.SqlClient;

namespace REMITTANCE.Infrastructure
{
    public class RemittanceRepository : IRemittanceRepository
    {
        private readonly IDbConnection _db;

        public RemittanceRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<int> AddAsync(Remittance remittance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "INSERT");
            parameters.Add("@UserId", remittance.UserId);
            parameters.Add("@UserName", remittance.UserName);
            parameters.Add("@AccountNumber", remittance.AccountNumber);
            parameters.Add("@IFSC_Code", remittance.IFSC_Code);
            parameters.Add("@SwiftCode", remittance.SwiftCode);
            parameters.Add("@TransactionType", remittance.TransactionType.ToString());
            parameters.Add("@Amount", remittance.Amount);
            parameters.Add("@FeeAmount", remittance.FeeAmount);
            parameters.Add("@Purpose", remittance.Purpose);
            parameters.Add("@Status", remittance.Status.ToString());
            parameters.Add("@UTRNumber", remittance.UTRNumber);
            parameters.Add("@CreatedBy", remittance.CreatedBy);

            return await _db.ExecuteAsync
                ("SP_Remittance", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Remittance remittance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "UPDATE");
            parameters.Add("@RemittanceId", remittance.RemittanceId);
            parameters.Add("@UserName", remittance.UserName);
            parameters.Add("@AccountNumber", remittance.AccountNumber);
            parameters.Add("@IFSC_Code", remittance.IFSC_Code);
            parameters.Add("@SwiftCode", remittance.SwiftCode);
            parameters.Add("@TransactionType", remittance.TransactionType.ToString());
            parameters.Add("@Amount", remittance.Amount);
            parameters.Add("@FeeAmount", remittance.FeeAmount);
            parameters.Add("@Purpose", remittance.Purpose);
            parameters.Add("@Status", remittance.Status.ToString());
            parameters.Add("@UTRNumber", remittance.UTRNumber);
            parameters.Add("@UpdatedBy", remittance.UpdatedBy);

            return await _db.ExecuteAsync
                ("SP_Remittance", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int remittanceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "DELETE");
            parameters.Add("@RemittanceId", remittanceId);

            return await _db.ExecuteAsync
                ("SP_Remittance", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int remittanceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETBYID");
            parameters.Add("@RemittanceId", remittanceId);

            return await _db.QueryFirstOrDefaultAsync<Remittance>
                ("SP_Remittance", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Flag", "GETALL");

            return await _db.QueryAsync<Remittance>
                ("SP_Remittance", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
