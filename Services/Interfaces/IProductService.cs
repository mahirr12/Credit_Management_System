using Credit_Management_System.Entities;
using Credit_Management_System.Models;

namespace Credit_Management_System.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductVM?> GetByIdAsync(int id);
        Task<IEnumerable<ProductVM>> GetAllAsync();
        Task CreateAsync(ProductVM productVM);
        Task<bool> UpdateAsync(ProductVM productVM);
        Task<bool> DeleteAsync(int id);
    }
}
