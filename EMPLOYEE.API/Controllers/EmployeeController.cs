using EMPLOYEE.Application;
using EMPLOYEE.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEE.API.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            if(result.StatusCode == 200)
            {
                return Ok(result);
            } 
            else if(result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetByEmployeeId")]
        public async Task<IActionResult> GetbyId(int EmployeeId)
        {
            var result = await _employeeService.GetEmployeeById(EmployeeId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeService.AddEmployeeAsync(employee);
            if (result.StatusCode == 201)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 400)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPatch("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(employee);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 204)
            {
                return StatusCode(StatusCodes.Status204NoContent, result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            var result = await _employeeService.DeleteEmployeeAsync(EmployeeId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 500)
            {
                return BadRequest(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
