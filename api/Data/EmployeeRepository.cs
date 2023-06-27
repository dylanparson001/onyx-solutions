using api.Entities;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class EmployeeRepository: IEmployeeRepository
{
    private readonly DataContext _context;
    
    // Constructor
    public EmployeeRepository(DataContext context)
    {
        _context = context;
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
        return await _context.Employees.ToListAsync();
    }
    
    // Get Employees by id
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);

    }
    // Get employees by username
    public async Task<Employee> GetEmployeeByUsername(string username)
    {
        return await _context.Employees.SingleOrDefaultAsync(x => x.UserName == username);
    }
}