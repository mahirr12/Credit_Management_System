using Credit_Management_System.Data;
using Credit_Management_System.Entities;
using Credit_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Credit_Management_System.Repositories.Implementations
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDBContext context) : base(context) { }

        public async Task<List<Branch>> GetAllWithIncludeAsync()
            => await _entity.Where(b => b.IsDeleted == false)
                            .Include(b => b.Merchant)
                            .Include(b => b.Employees)
                            .ToListAsync();

        //get branch by id with their merchant and employees
        public async Task<Branch?> GetByIdWithIncludeAsync(int id)
            => await _entity.Where(m => m.IsDeleted == false)
                            .Include(b => b.Merchant)
                            .Include(b => b.Employees)
                            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
