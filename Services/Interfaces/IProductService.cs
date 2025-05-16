using Credit_Management_System.Entities;
using Credit_Management_System.Models;

namespace Credit_Management_System.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVM>> GetAllAsync();
        Task<ProductVM?> GetByIdAsync(int id);
        Task CreateAsync(ProductVM model);
        Task UpdateAsync(ProductVM model);
        Task DeleteAsync(int id);
    }
}
