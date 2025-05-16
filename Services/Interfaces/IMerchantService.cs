using Credit_Management_System.Entities;
using Credit_Management_System.Models;

namespace Credit_Management_System.Services.Interfaces
{
    public interface IMerchantService
    {
        Task<List<MerchantVM>> GetAllAsync();
        Task<MerchantVM?> GetByIdAsync(int id);
        Task CreateAsync(MerchantVM merchantVM);
        Task<bool> UpdateAsync(MerchantVM merchantVM);
        Task<bool> DeleteAsync(int id);
    }
}
