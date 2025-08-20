using Dapper;
using DIGITAL_SESSIONS.Application;
using DIGITAL_SESSIONS.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DIGITAL_SESSIONS.Infrastructure
{
    public class DigitalSessionRepository : IDigitalSessionRepository
    {
        private readonly IDbConnection _db;

        public DigitalSessionRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETALL");

            return await _db.QueryAsync<dynamic>
                ("[dbo].[SP_DigitalSessions]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetByIdAsync(int sessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETBYID");
            parameters.Add("@SessionId", sessionId);

            return await _db.QueryFirstOrDefaultAsync<dynamic>
                ("[dbo].[SP_DigitalSessions]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(DigitalSession session)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "INSERT");
            parameters.Add("@UserId", session.UserId);
            parameters.Add("@DeviceId", session.DeviceId);
            parameters.Add("@LogoutTime", session.LogoutTime);
            parameters.Add("@IpAddress", session.IpAddress);
            parameters.Add("@IsTrusted", session.IsTrusted);
            parameters.Add("@CreatedBy", session.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DigitalSessions]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(DigitalSession session)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "UPDATE");
            parameters.Add("@SessionId", session.SessionId);
            parameters.Add("@UserId", session.UserId);
            parameters.Add("@DeviceId", session.DeviceId);
            parameters.Add("@LoginTime", session.LoginTime);
            parameters.Add("@LogoutTime", session.LogoutTime);
            parameters.Add("@IpAddress", session.IpAddress);
            parameters.Add("@IsTrusted", session.IsTrusted);
            parameters.Add("@UpdatedBy", session.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DigitalSessions]", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int sessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "DELETE");
            parameters.Add("@SessionId", sessionId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_DigitalSessions]", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
