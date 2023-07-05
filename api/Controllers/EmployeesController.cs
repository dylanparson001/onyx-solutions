using api.Data;
using api.DTOs;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Authorize] // Requires authentication in order to use these endpoints
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        // Datacontext injection
        private readonly DataContext _context;
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetEmployees()
        {
            
            var employees = await _employeeRepository.GetMembersAsync();

            return Ok(employees);

        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetEmployee(string username)
        {
            return await _employeeRepository.GetMemberAsync(username);
            
        }
    }
}
