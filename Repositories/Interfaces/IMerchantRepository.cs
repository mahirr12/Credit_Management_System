using Credit_Management_System.Entities;

namespace Credit_Management_System.Repositories.Interfaces
{
    public interface IMerchantRepository : IGenericRepository<Merchant>
    {
        Task<IEnumerable<Merchant>> GetAllWithIncludeAsync();
        Task<Merchant?> GetByIdWithIncludeAsync(int id);
    }
}
