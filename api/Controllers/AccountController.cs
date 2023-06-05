using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Entities;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
            
        }
        
        // POST: api/account/register
        [HttpPost("register")]
        public async Task<ActionResult<EmployeeDto>> Register(RegisterDto registerDto)
        {
            if(await EmployeeExists(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var employee = new Employee{
                UserName = registerDto.Username.ToUpper(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return new EmployeeDto
            {
                Username = employee.UserName,
                Token = _tokenService.CreateToken(employee)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<EmployeeDto>> Login(LoginDto loginDto)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(
                x => x.UserName == loginDto.Username);
            
            if(employee == null) return Unauthorized();
                
            using var hmac = new HMACSHA512(employee.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computedHash.Length; i++){
                if(computedHash[i] != employee.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new EmployeeDto
            {
                Username = employee.UserName,
                Token = _tokenService.CreateToken(employee)
            };
        }

        private async Task<bool> EmployeeExists(string username)
        {
            return await _context.Employees.AnyAsync(x => x.UserName == username.ToUpper());
        }
    }
}