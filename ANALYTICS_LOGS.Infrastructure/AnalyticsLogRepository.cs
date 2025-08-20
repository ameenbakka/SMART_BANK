using ANALYTICS_LOGS.Application;
using ANALYTICS_LOGS.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ANALYTICS_LOGS.Infrastructure
{
    public class AnalyticsLogRepository : IAnalyticsLogRepository
    {
        private readonly IDbConnection _db;
        public AnalyticsLogRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }
        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETALL");

            return await _db.QueryAsync<AnalyticsLog>
                ("[dbo].[SP_AnalyticsLogs]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int logId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETBYID");
            parameters.Add("@LogId", logId);

            return await _db.QueryFirstOrDefaultAsync<AnalyticsLog>
                ("[dbo].[SP_AnalyticsLogs]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(AnalyticsLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("@Module", log.Module);
            parameters.Add("@Metric", log.Metric);
            parameters.Add("@Value", log.Value);
            parameters.Add("@CreatedBy", log.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_AnalyticsLogs]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(AnalyticsLog log)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@LogId", log.LogId);
            parameters.Add("@Module", log.Module);
            parameters.Add("@Metric", log.Metric);
            parameters.Add("@Value", log.Value);
            parameters.Add("@UpdatedBy", log.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_AnalyticsLogs]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int logId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@LogId", logId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_AnalyticsLogs]",parameters,commandType: CommandType.StoredProcedure);
        }
    }
}
