using ACCOUNT.Application;
using EMPLOYEE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE.Application
{
    public interface IEmployeeService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllEmployeesAsync();
        Task<ApiResponse<dynamic>> GetEmployeeById(int employeeId);
        Task<ApiResponse<int>> AddEmployeeAsync(Employee employee);
        Task<ApiResponse<int>> UpdateEmployeeAsync(Employee employee);
        Task<ApiResponse<int>> DeleteEmployeeAsync(int EmployeeId);
    }
}
