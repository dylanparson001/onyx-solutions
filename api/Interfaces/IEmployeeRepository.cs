using api.Entities;

namespace api.Interfaces;

public interface IEmployeeRepository
{
    void Update(Employee employee);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> GetEmployeeByUsername(string username);
}