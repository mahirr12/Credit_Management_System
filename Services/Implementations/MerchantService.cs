using Credit_Management_System.Entities;
using Credit_Management_System.Models;
using Credit_Management_System.Repositories.Interfaces;
using Credit_Management_System.Services.Interfaces;

namespace Credit_Management_System.Services.Implementations
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepo;
        public MerchantService(IMerchantRepository merchantRepo)
        {
            _merchantRepo = merchantRepo;
        }
        public async Task CreateAsync(MerchantVM merchantVM)
        {
            var merchant = new Merchant
            {
                Name = merchantVM.Name
            };
            await _merchantRepo.AddAsync(merchant);
            await _merchantRepo.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var merchant = await _merchantRepo.GetByIdAsync(id);
            if (merchant == null) return false;

            _merchantRepo.Delete(merchant);
            await _merchantRepo.SaveChangesAsync();
            return true;
        }

        public async Task<List<MerchantVM>> GetAllAsync()
        {
            var merchants = await _merchantRepo.GetAllWithIncludeAsync();
            var merchantVMs = merchants.Select(m => new MerchantVM
            {
                Id = m.Id,
                Name = m.Name,
                BranchIds = [.. m.Branches.Select(b => b.Id)]
            });
            return [.. merchantVMs];
        }
        public async Task<MerchantVM?> GetByIdAsync(int id)
        {
            var merchant = await _merchantRepo.GetByIdWithIncludeAsync(id);
            if (merchant == null) return null;

            var merchantVM = new MerchantVM
            {
                Id = merchant.Id,
                Name = merchant.Name,
                BranchIds = [.. merchant.Branches.Select(b => b.Id)]
            };
            return merchantVM;
        }
        public async Task<bool> UpdateAsync(MerchantVM merchantVM)
        {
            var merchant = await _merchantRepo.GetByIdAsync(merchantVM.Id);
            if (merchant == null) return false;

            merchant.Name = merchantVM.Name;

            _merchantRepo.Update(merchant);
            await _merchantRepo.SaveChangesAsync();
            return true;
        }
    }
}
