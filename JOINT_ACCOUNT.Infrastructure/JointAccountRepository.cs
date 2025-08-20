using Dapper;
using JOINT_ACCOUNT.Application;
using JOINT_ACCOUNT.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOINT_ACCOUNT.Infrastructure
{
    public class JointAccountRepository : IJointAccountRepository
    {
        private readonly IDbConnection _db;
        public JointAccountRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }
        public async Task<IEnumerable<dynamic>> GetAllJointAccountsAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETALL");

            return await _db.QueryAsync<JointAccount>
                ("[dbo].[SP_JointAccount]",parameters,commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetJointAccountByIdAsync(int jointAccountId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETBYID");
            parameters.Add("@JointAccountId", jointAccountId);

            return await _db.QueryFirstOrDefaultAsync<JointAccount>
                ("[dbo].[SP_JointAccount]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddJointAccountAsync(JointAccount jointAccount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("@AccountId", jointAccount.AccountId);
            parameters.Add("@UserId", jointAccount.UserId);
            parameters.Add("@Relationship", jointAccount.Relationship);
            parameters.Add("@JointType", jointAccount.JointType);
            parameters.Add("@CreatedBy", jointAccount.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_JointAccount]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateJointAccountAsync(JointAccount jointAccount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@JointAccountId", jointAccount.JointAccountId);
            parameters.Add("@Relationship", jointAccount.Relationship);
            parameters.Add("@JointType", jointAccount.JointType);
            parameters.Add("@UpdatedBy", jointAccount.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_JointAccount]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteJointAccountAsync(int jointAccountId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@JointAccountId", jointAccountId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_JointAccount]", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
