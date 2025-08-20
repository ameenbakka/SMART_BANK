using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using USER_AUDIT_LOGS.Application;
using USER_AUDIT_LOGS.Domain;

namespace USER_AUDIT_LOGS.Infrastructure
{
    public class UserAuditLogsRepository : IUserAuditLogRepository
    {
        private readonly IDbConnection _db;

        public UserAuditLogsRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETALL");
            return await _db.QueryAsync<UserAuditLog>
                ("SP_UserAuditLogs", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int logId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETBYID");
            parameters.Add("@LogId", logId);
            return await _db.QueryFirstOrDefaultAsync<UserAuditLog>
                ("SP_UserAuditLogs", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(UserAuditLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "INSERT");
            parameters.Add("@UserId", log.UserId);
            parameters.Add("@Action", log.Action);
            parameters.Add("@Description", log.Description);
            parameters.Add("@CreatedBy", log.CreatedBy);

            return await _db.ExecuteAsync
                ("SP_UserAuditLogs", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(UserAuditLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "UPDATE");
            parameters.Add("@LogId", log.LogId);
            parameters.Add("@UserId", log.UserId);
            parameters.Add("@Action", log.Action);
            parameters.Add("@Description", log.Description);
            parameters.Add("@UpdatedBy", log.UpdatedBy);

            return await _db.ExecuteAsync
                ("SP_UserAuditLogs", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int logId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "DELETE");
            parameters.Add("@LogId", logId);

            return await _db.ExecuteAsync
                ("SP_UserAuditLogs", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
