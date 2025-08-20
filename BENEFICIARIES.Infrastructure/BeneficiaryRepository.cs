using BENEFICIARIES.Application;
using BENEFICIARIES.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BENEFICIARIES.Infrastructure
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly IDbConnection _db;

        public BeneficiaryRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("Flag", "GETALL");

            return await _db.QueryAsync<dynamic>
                ("SP_Beneficiaries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int beneficiaryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Flag", "GETBYID");
            parameters.Add("BeneficiaryId", beneficiaryId);

            return await _db.QueryFirstOrDefaultAsync<dynamic>
                ("SP_Beneficiaries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(Beneficiary beneficiary)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Flag", "INSERT");
            parameters.Add("UserId", beneficiary.UserId);
            parameters.Add("NickName", beneficiary.NickName);
            parameters.Add("Name", beneficiary.Name);
            parameters.Add("BankName", beneficiary.BankName);
            parameters.Add("BranchName", beneficiary.BranchName);
            parameters.Add("AccountNumber", beneficiary.AccountNumber);
            parameters.Add("IFSC_Code", beneficiary.IFSC_Code);
            parameters.Add("TransactionType", beneficiary.TransactionType);
            parameters.Add("Status", beneficiary.Status);
            parameters.Add("VerificationStatus", beneficiary.VerificationStatus);
            parameters.Add("CreatedBy", beneficiary.CreatedBy);

            return await _db.ExecuteAsync
                ("SP_Beneficiaries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Beneficiary beneficiary)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Flag", "UPDATE");
            parameters.Add("BeneficiaryId", beneficiary.BeneficiaryId);
            parameters.Add("NickName", beneficiary.NickName);
            parameters.Add("Name", beneficiary.Name);
            parameters.Add("BankName", beneficiary.BankName);
            parameters.Add("BranchName", beneficiary.BranchName);
            parameters.Add("IFSC_Code", beneficiary.IFSC_Code);
            parameters.Add("TransactionType", beneficiary.TransactionType);
            parameters.Add("Status", beneficiary.Status);
            parameters.Add("VerificationStatus", beneficiary.VerificationStatus);
            parameters.Add("UpdatedBy", beneficiary.UpdatedBy);

            return await _db.ExecuteAsync
                ("SP_Beneficiaries", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int beneficiaryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Flag", "DELETE");
            parameters.Add("BeneficiaryId", beneficiaryId);

            return await _db.ExecuteAsync
                ("SP_Beneficiaries", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
