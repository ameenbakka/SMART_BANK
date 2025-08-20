using ACCOUNT.Application;
using Dapper;
using Microsoft.Extensions.Configuration;
using NOMINEE.Application;
using NOMINEE.Domain;
using System.Data;
using System.Data.SqlClient;

namespace NOMINEE.Infrastructure
{
    public class NomineeRepository : INomineeRepository
    {
        private readonly IDbConnection _db;

        public NomineeRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETALL");

            return await _db.QueryAsync<Nominee>(
                "SP_Nominees", parameters, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetByIdAsync(int nomineeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETBYID");
            parameters.Add("@NomineeId", nomineeId);

            return await _db.QueryFirstOrDefaultAsync<Nominee>(
                "SP_Nominees", parameters, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> AddAsync(Nominee nominee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "INSERT");
            parameters.Add("@USERID", nominee.USERID);
            parameters.Add("@AccountId", nominee.AccountId);
            parameters.Add("@Name", nominee.Name);
            parameters.Add("@DateOfBirth", nominee.DateOfBirth);
            parameters.Add("@Relation", nominee.Relation);
            parameters.Add("@Email", nominee.Email);
            parameters.Add("@PhoneNumber", nominee.PhoneNumber);
            parameters.Add("@SharePercentage", nominee.SharePercentage);
            parameters.Add("@CreatedBy", nominee.CreatedBy);

            return await _db.ExecuteAsync(
                "SP_Nominees", parameters, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(Nominee nominee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "UPDATE");
            parameters.Add("@NomineeId", nominee.NomineeId);
            parameters.Add("@Name", nominee.Name);
            parameters.Add("@DateOfBirth", nominee.DateOfBirth);
            parameters.Add("@Relation", nominee.Relation);
            parameters.Add("@Email", nominee.Email);
            parameters.Add("@PhoneNumber", nominee.PhoneNumber);
            parameters.Add("@SharePercentage", nominee.SharePercentage);
            parameters.Add("@UpdatedBy", nominee.UpdatedBy);

            return await _db.ExecuteAsync(
                "SP_Nominees", parameters, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteAsync(int nomineeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "DELETE");
            parameters.Add("@NomineeId", nomineeId);

            return await _db.ExecuteAsync(
                "SP_Nominees", parameters, commandType: CommandType.StoredProcedure
            );
        }
    }
}
