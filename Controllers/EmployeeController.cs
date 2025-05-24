using Credit_Management_System.Models;
using Credit_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Management_System.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController(IProductService productService, ICategoryService categoryService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;

        public IActionResult Index()
        {
            return View();
        }
        //Category
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAllAsync();
            var parentCategories = await _categoryService.GetCategorySelectListAsync();
            ViewBag.ParentCategories = parentCategories;
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return RedirectToAction("CategoryList", result);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            var model = new CategoryVM()
            {
                ParentCategories = await _categoryService.GetCategorySelectListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                categoryVM.ParentCategories = await _categoryService.GetCategorySelectListAsync();
                return View(categoryVM);
            }
            await _categoryService.CreateAsync(categoryVM);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                categoryVM.ParentCategories = await _categoryService.GetCategorySelectListAsync();
                return View(categoryVM);
            }
            await _categoryService.UpdateAsync(categoryVM);
            return RedirectToAction("CategoryList");
        }


        //Product
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
    }
}
