using ACCOUNT.Application;
using EMPLOYEE.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllEmployeesAsync()
        {
            try
            {
                var result = await _employeeRepo.GetAllEmployees();
                return new ApiResponse<IEnumerable<dynamic>>(200, "Employees Retrived Successfully",result);
            }
            catch(SqlException ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<dynamic>>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<dynamic>> GetEmployeeById(int employeeId)
        {
            try
            {
                var result = await _employeeRepo.GetEmployeeById(employeeId);
                if (result != null)
                    return new ApiResponse<dynamic>(200, "Employee Retrived Successfully",result);

                return new ApiResponse<dynamic>(404, "Not found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<dynamic>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<dynamic>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> AddEmployeeAsync(Employee employee)
        {
            try
            {
                var result = await _employeeRepo.AddEmployeeAsync(employee);
                if (result > 0)
                    return new ApiResponse<int>(201, "Employee Created Successfully", result);

                return new ApiResponse<int>(400, "Bad Requset");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
        public async Task<ApiResponse<int>> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var result = await _employeeRepo.UpdateEmployeeAsync(employee);
                if (result > 0)
                    return new ApiResponse<int>(200, "Employee Updated Successfully", result);

                return new ApiResponse<int>(404, "Not Found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        } 
        public async Task<ApiResponse<int>> DeleteEmployeeAsync(int EmployeeId)
        {
            try
            {
                var result = await _employeeRepo.DeleteEmployeeAsync(EmployeeId);
                if (result > 0)
                    return new ApiResponse<int>(200, "Employee Deleted Successfully", result);

                return new ApiResponse<int>(404, "Not found");
            }
            catch (SqlException ex)
            {
                return new ApiResponse<int>(500, $"SQL Exception : {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(500, $"Unexpected Error : {ex.Message}");
            }
        }
    }
}
