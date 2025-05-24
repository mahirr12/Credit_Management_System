using Credit_Management_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Management_System.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryVM?> GetByIdAsync(int id);
        Task<IEnumerable<CategoryVM>> GetAllAsync();
        Task CreateAsync(CategoryVM categoryVM);
        Task<bool> UpdateAsync(CategoryVM categoryVM);
        Task<bool> DeleteAsync(int id);
        Task<List<SelectListItem>> GetCategorySelectListAsync();
    }
}
