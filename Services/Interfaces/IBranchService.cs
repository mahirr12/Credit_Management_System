using Credit_Management_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Management_System.Services.Interfaces
{
    public interface IBranchService
    {
        Task<List<BranchVM>> GetAllAsync();
        Task<BranchVM?> GetByIdAsync(int id);
        Task CreateAsync(BranchVM branchVM);
        Task<bool> UpdateAsync(BranchVM branchVM);
        Task<bool> DeleteAsync(int id);
        Task<List<SelectListItem>> GetMerchantsSelectListAsync();
        Task<List<SelectListItem>> GetBranchesSelectListAsync();
    }
}
