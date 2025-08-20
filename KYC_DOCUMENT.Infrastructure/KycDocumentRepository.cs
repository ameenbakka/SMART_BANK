using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KYC_DOCUMENT.Infrastructure
{
    public class KycDocumentRepository
    {
        private readonly IDbConnection _db;
        public KycDocumentRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("defaultconnection"));
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", 1);

            return await _db.QueryAsync<>
                ("SP_KYCDocument", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
