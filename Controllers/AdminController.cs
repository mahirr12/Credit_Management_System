using Credit_Management_System.Models;
using Credit_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMerchantService _merchantService;

        public AdminController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateMerchant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant(MerchantVM merchantVM)
        {
            if (!ModelState.IsValid)
            {
                return View(merchantVM);
            }
            // Call the service to create the merchant
            await _merchantService.CreateAsync(merchantVM);
            return RedirectToAction("MerchantList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var result = await _merchantService.DeleteAsync(id);
            return RedirectToAction("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> MerchantList()
        {
            var merchants = await _merchantService.GetAllAsync();
            return View(merchants);
        }
    }
}
