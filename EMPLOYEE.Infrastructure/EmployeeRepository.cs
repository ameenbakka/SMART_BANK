using Dapper;
using EMPLOYEE.Application;
using EMPLOYEE.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EMPLOYEE.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;
        public EmployeeRepository(IConfiguration confiquration)
        {
            _db = new SqlConnection(confiquration.GetConnectionString("defaultconnection"));
        }
        public async Task<IEnumerable<dynamic>> GetAllEmployees()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETALL");

            return await _db.QueryAsync<Employee>
                ("[dbo].[SP_Employee]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetEmployeeById(int EmployeeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "GETBYID");
            parameters.Add("@EmployeeId",EmployeeId);

            return await _db.QueryFirstOrDefaultAsync<Employee>
                ("[dbo].[Employee]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "INSERT");
            parameters.Add("@BranchId", employee.BranchId);
            parameters.Add("@FirstName", employee.FirstName);
            parameters.Add("@LastName", employee.LastName);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@PhoneNumber", employee.PhoneNumber);
            parameters.Add("@Role", employee.Role);
            parameters.Add("@CreatedBy", employee.CreatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Employee]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "UPDATE");
            parameters.Add("@EmployeeId", employee.EmployeeId);
            parameters.Add("@BranchId", employee.BranchId);
            parameters.Add("@FirstName", employee.FirstName);
            parameters.Add("@LastName", employee.LastName);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@PhoneNumber", employee.PhoneNumber);
            parameters.Add("@Role", employee.Role);
            parameters.Add("@UpdatedAt", DateTime.Now);
            parameters.Add("@UpdatedBy", employee.UpdatedBy);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Employee]", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteEmployeeAsync(int EmployeeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FLAG", "DELETE");
            parameters.Add("@EmployeeId", EmployeeId);

            return await _db.ExecuteAsync
                ("[dbo].[SP_Employee]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
