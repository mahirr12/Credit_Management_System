using Credit_Management_System.Entities;
using Credit_Management_System.Models;
using Credit_Management_System.Repositories.Interfaces;
using Credit_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Management_System.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepo;
        private readonly IGenericRepository<Merchant> _merchantRepo;
        public BranchService(IBranchRepository branchRepo, IGenericRepository<Merchant> merchantRepo)
        {
            _branchRepo = branchRepo;
            _merchantRepo = merchantRepo;
        }

        public async Task CreateAsync(BranchVM branchVM)
        {
            var merchant = await _merchantRepo.GetByIdAsync(branchVM.MerchantId);
            if (merchant == null) throw new Exception("Merchant not found");
            var branch = new Branch
            {
                Name = branchVM.Name.Trim(),
                MerchantId = branchVM.MerchantId
            };
            await _branchRepo.AddAsync(branch);
            await _branchRepo.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var branch = await _branchRepo.GetByIdAsync(id);
            if (branch == null) return false;
            _branchRepo.Delete(branch);
            await _branchRepo.SaveChangesAsync();
            return true;
        }
        public async Task<List<BranchVM>> GetAllAsync()
        {
            var branches = await _branchRepo.GetAllWithIncludeAsync();
            var branchVMs = branches.Select(b => new BranchVM
            {
                Id = b.Id,
                Name = b.Name,
                MerchantId = b.MerchantId,
                EmployeeIds = [.. b.Employees.Select(e => e.Id)],
            }).ToList();

            return [.. branchVMs];
        }
        public async Task<BranchVM?> GetByIdAsync(int id)
        {
            var branch = await _branchRepo.GetByIdWithIncludeAsync(id);
            if (branch == null) return null;
            var branchVM = new BranchVM
            {
                Id = branch.Id,
                Name = branch.Name,
                MerchantId = branch.MerchantId,
                EmployeeIds = [.. branch.Employees.Select(e => e.Id)],
            };
            return branchVM;
        }
        public async Task<bool> UpdateAsync(BranchVM branchVM)
        {
            var branch = await _branchRepo.GetByIdAsync(branchVM.Id);
            if (branch == null) return false;
            branch.Name = branchVM.Name.Trim();
            branch.MerchantId = branchVM.MerchantId;
            _branchRepo.Update(branch);
            await _branchRepo.SaveChangesAsync();
            return true;
        }
        public async Task<List<SelectListItem>> GetMerchantsSelectListAsync()
        {
            var merchants = await _merchantRepo.GetAllAsync();
            var selectList = merchants.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            }).ToList();
            return selectList;
        }

        public async Task<List<SelectListItem>> GetBranchesSelectListAsync()
        {
            var branches = await _branchRepo.GetAllWithIncludeAsync();
            var selectList = branches.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Merchant.Name + " " + b.Name
            }).ToList();
            return selectList;

        }
    }
}
