using Credit_Management_System.Entities;

namespace Credit_Management_System.Repositories.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync(List<int> ids);
    }
}
