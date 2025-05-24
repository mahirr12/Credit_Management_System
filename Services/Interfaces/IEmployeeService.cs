using Credit_Management_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Management_System.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeVM>> GetAllAsync();
        Task<EmployeeVM?> GetByIdAsync(string id);
        Task<bool> CreateAsync(EmployeeVM model);
        Task<bool> UpdateAsync( EmployeeVM employee);
        Task<bool> DeleteAsync(string id);
        Task<bool> ChangePasswordAsync(string id, string newPassword, string currentPassword);
    }
}
