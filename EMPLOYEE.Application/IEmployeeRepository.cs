using EMPLOYEE.Domain;

namespace EMPLOYEE.Application
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<dynamic>> GetAllEmployees();
        Task<dynamic> GetEmployeeById(int EmployeeId);
        Task<int> AddEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(int EmployeeId);

    }
}
