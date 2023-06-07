using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Authorize] // Requires authentication in order to use these endpoints
    public class EmployeesController : BaseApiController
    {
        // Datacontext injection
        private readonly DataContext _context;
        public EmployeesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous] // does not required authentication to use
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return employee;
        }
    }
}