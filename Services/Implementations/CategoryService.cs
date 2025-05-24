using Credit_Management_System.Entities;
using Credit_Management_System.Models;
using Credit_Management_System.Repositories.Interfaces;
using Credit_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Credit_Management_System.Services.Implementations
{
    public class CategoryService(IGenericRepository<Category> categoryRepo) : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepo = categoryRepo;

        public async Task CreateAsync(CategoryVM categoryVM)
        {
            var category = new Category
            {
                Title = categoryVM.Title.Trim(),
                ParentCategoryId = categoryVM.ParentCategoryId,
            };
            await _categoryRepo.AddAsync(category);
            await _categoryRepo.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return false;
            _categoryRepo.Delete(category);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoryVMs = categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Title = c.Title,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList();
            return categoryVMs;
        }
        public async Task<CategoryVM?> GetByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return null;
            var categoryVM = new CategoryVM
            {
                Id = category.Id,
                Title = category.Title,
                ParentCategoryId = category.ParentCategoryId,
            };
            return categoryVM;
        }
        public async Task<List<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var selectListItems = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title,
            }).ToList();
            return selectListItems;
        }
        public async Task<bool> UpdateAsync(CategoryVM categoryVM)
        {
            var category = await _categoryRepo.GetByIdAsync(categoryVM.Id);
            if (category == null) return false;
            category.Title = categoryVM.Title.Trim();
            category.ParentCategoryId = categoryVM.ParentCategoryId;
            _categoryRepo.Update(category);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }
    }
}
