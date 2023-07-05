using api.DTOs;
using api.Entities;

namespace api.Interfaces;

public interface IEmployeeRepository
{
    void Update(Employee employee);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> GetEmployeeByUsernameAsync(string username);
    Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<MemberDto> GetMemberAsync(string username);
}