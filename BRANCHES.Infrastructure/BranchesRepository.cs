using BRANCHES.Application;
using BRANCHES.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BRANCHES.Infrastructure
{
    public class BranchesRepository : IBranchesRepository
    {
        private readonly IDbConnection _db;
        public BranchesRepository( IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("defaultconnection")) ;
        }

        public async Task<IEnumerable<dynamic>> GetAllBranchesAsync()
        {
            var parameter = new DynamicParameters();
            parameter.Add("FLAG", "GETALL");

            return await _db.QueryAsync<Branch>
                ("[dbo].[SP_Branches]", parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetByBranchIdAsync(int BranchId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("FLAG", "GETBYID");
            parameter.Add("@BrachId", BranchId);

            return await _db.QueryFirstOrDefaultAsync<Branch>
                ("[dbo].[Branches]", parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddBranchAsync(Branch branch)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("@BranchCode", branch.BranchCode);
            parameters.Add("@BranchName", branch.BranchName);
            parameters.Add("@Ifsc_Code", branch.Ifsc_Code);
            parameters.Add("@Address", branch.Address);
            parameters.Add("@City", branch.City);
            parameters.Add("@State", branch.State);
            parameters.Add("@Country", branch.Country);
            parameters.Add("@Latitude", branch.Latitude);
            parameters.Add("@Longitude", branch.Longitude);
            parameters.Add("@CreatedAt", branch.CreatedAt);
            parameters.Add("@UpdatedAt", branch.UpdatedAt);

            return await _db.ExecuteAsync
                ("[dbo].[Branches]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateBranchAsync(Branch branch)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@BranchCode", branch.BranchCode);
            parameters.Add("@BranchName", branch.BranchName);
            parameters.Add("@Ifsc_Code", branch.Ifsc_Code);
            parameters.Add("@Address", branch.Address);
            parameters.Add("@City", branch.City);
            parameters.Add("@State", branch.State);
            parameters.Add("@Country", branch.Country);
            parameters.Add("@Latitude", branch.Latitude);
            parameters.Add("@Longitude", branch.Longitude);
            parameters.Add("@CreatedAt", branch.CreatedAt);
            parameters.Add("@UpdatedAt", DateTime.UtcNow);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Branches]", parameters, commandType: CommandType.StoredProcedure); 
        }
        public async Task<int> DeleteBranchesAsync(int BranchId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@BrachId", BranchId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Branches]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
