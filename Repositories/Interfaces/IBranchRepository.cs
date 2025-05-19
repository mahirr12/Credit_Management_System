using Credit_Management_System.Entities;

namespace Credit_Management_System.Repositories.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<List<Branch>> GetAllWithIncludeAsync();
        Task<Branch?> GetByIdWithIncludeAsync(int id);
    }

}
