using api.DTOs;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class EmployeeRepository: IEmployeeRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    // Constructor
    public EmployeeRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // Update Employee
    public void Update(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
    }
    // Save Changes
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    // Get all employees
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.Include(p => p.Photos)
        .ToListAsync();
    }
    
    // Get Employees by id
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);

    }
    // Get employees by username
    public async Task<Employee> GetEmployeeByUsernameAsync(string username)
    {
        return await _context.Employees
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _context.Employees
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<MemberDto> GetMemberAsync(string username)
    {
        return await _context.Employees
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}