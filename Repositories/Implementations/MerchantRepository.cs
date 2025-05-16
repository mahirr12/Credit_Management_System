using Credit_Management_System.Data;
using Credit_Management_System.Entities;
using Credit_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Management_System.Repositories.Implementations
{
    public class MerchantRepository : GenericRepository<Merchant>, IMerchantRepository
    {
        public MerchantRepository(AppDBContext context) : base(context) { }

        public async Task<IEnumerable<Merchant>> GetAllWithIncludeAsync()
            => await _entity.Where(m => m.IsDeleted == false)
                            .Include(m => m.Branches)
                            .ToListAsync();

        public async Task<Merchant?> GetByIdWithIncludeAsync(int id)
            => await _entity.Where(m => m.IsDeleted == false)
                            .Include(m => m.Branches)
                            .FirstOrDefaultAsync(m => m.Id == id);
    }
}
