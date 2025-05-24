using Credit_Management_System.Entities;
using Credit_Management_System.Models;
using Credit_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Credit_Management_System.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<User> _userManager;

        public EmployeeService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<EmployeeVM>> GetAllAsync()
        {
            var employees = await _userManager.Users.OfType<Employee>().ToListAsync();

            var models = employees.Select(e => new EmployeeVM
            {
                Id = e.Id,
                Name = e.Name,
                LastName = e.LastName,
                Email = e.Email,
                BranchId = e.BranchId,
                LoanIds = [.. e.Loans.Select(e => e.Id)]
            }).ToList();

            return models;
        }
        public async Task<EmployeeVM?> GetByIdAsync(string id)
        {
            var employee = await _userManager.Users.OfType<Employee>().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (employee == null) return null;
            var model = new EmployeeVM
            {
                Id = employee.Id,
                Name = employee.Name,
                LastName = employee.LastName,
                Email = employee.Email,
                BranchId = employee.BranchId,
                LoanIds = [.. employee.Loans.Select(e => e.Id)]
            };
            return model;
        }
        public async Task<bool> CreateAsync(EmployeeVM model)
        {
            if (!await _userManager.Users.OfType<Employee>().AnyAsync(e => e.Email == model.Email))
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    BranchId = model.BranchId,
                    UserName = model.Email,
                    EmailConfirmed = true
                };
                
                var result = await _userManager.CreateAsync(employee, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(employee, "Employee");
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else return false;
        }

        public async Task<bool> UpdateAsync(EmployeeVM model)
        {
            var employee = await _userManager.Users.OfType<Employee>().FirstOrDefaultAsync(e => e.Id == model.Id && !e.IsDeleted);
            if (employee == null) return false;
            employee.Name = model.Name;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.BranchId = model.BranchId;
            var result = await _userManager.UpdateAsync(employee);
            return result.Succeeded;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var employee = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (employee == null) return false;
            employee.IsDeleted = true;
            var result = await _userManager.UpdateAsync(employee);
            return result.Succeeded;
        }

        public async Task<bool> ChangePasswordAsync(string id, string newPassword, string currentPassword)
        {
            var employee = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (employee == null) return false;
            var result = await _userManager.ChangePasswordAsync(employee, currentPassword, newPassword);
            return result.Succeeded;
        }
    }
}
