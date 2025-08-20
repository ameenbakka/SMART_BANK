using Dapper;
using EMPLOYEE_AUDIT_LOGS.Application;
using EMPLOYEE_AUDIT_LOGS.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EMPLOYEE_AUDIT_LOGS.Infrastructure
{
    public class EmployeeAuditLogRepository : IEmployeeAuditLogRepository
    {
        private readonly IDbConnection _db;
        public EmployeeAuditLogRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETALL");

            return await _db.QueryAsync<EmployeeAuditLog>
                ("[dbo].[SP_EmployeeAuditLogs]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetById(int LogId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETBYID");
            parameters.Add("@LogId", LogId);

            return await _db.QueryFirstOrDefaultAsync<EmployeeAuditLog>
                ("[dbo].[SP_EmployeeAuditLogs]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddAuditLogAsync(EmployeeAuditLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("EmployeeId", log.EmployeeId);
            parameters.Add("Action", log.Action);
            parameters.Add("Description", log.Description);
            parameters.Add("CreatedBy", log.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_EmployeeAuditLogs]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAuditLogAsync(EmployeeAuditLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("LogId", log.LogId);
            parameters.Add("EmployeeId", log.EmployeeId);
            parameters.Add("Action", log.Action);
            parameters.Add("Description", log.Description);
            parameters.Add("UpdatedBy", log.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_EmployeeAuditLogs]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteAsync(int LogId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@LogId", LogId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_EmployeeAuditLogs]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
