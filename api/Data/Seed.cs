using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class Seed
{
    public static async Task SeedEmployees(DataContext context)
    {
        if (await context.Employees.AnyAsync()) return;

        var employeeData = await File.ReadAllTextAsync("Data/EmployeeSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var employees = JsonSerializer.Deserialize<List<Employee>>(employeeData);

        foreach (var employee in employees)
        {
            using var hmac = new HMACSHA512();

            employee.UserName = employee.UserName.ToUpper();
            employee.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
            employee.PasswordSalt = hmac.Key;

            context.Employees.Add(employee);
        }

        await context.SaveChangesAsync();
    }
}