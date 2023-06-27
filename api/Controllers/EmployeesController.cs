using api.Data;
using api.Entities;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Authorize] // Requires authentication in order to use these endpoints
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Datacontext injection
        private readonly DataContext _context;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeeRepository.GetEmployeesAsync());

         
        }

        /*[HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return employee;
        }*/
    }
}

/*
 * using api.Data;
using api.Entities;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Authorize] // Requires authentication in order to use these endpoints
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return employees;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Employee>> GetEmployee(string username)
        {
            return await _employeeRepository.GetEmployeeByUsername(username);
        }
    }
}
 */