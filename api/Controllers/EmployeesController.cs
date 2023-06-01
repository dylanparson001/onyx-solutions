using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees(){
            var employees = _context.Employees.ToList();

            return employees;
        }
        [HttpGet("{id}")]
          public ActionResult<Employee> GetEmployee(int id){
            var employee = _context.Employees.Find(id);

            return employee;
         }
    }
}