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
        private readonly IBranchService _branchService;

        public AdminController(IMerchantService merchantService, IBranchService branchService)
        {
            _merchantService = merchantService;
            _branchService = branchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Merchant
        [HttpGet]
        public async Task<IActionResult> MerchantList()
        {
            var merchants = await _merchantService.GetAllAsync();
            return View(merchants);
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
            return RedirectToAction("MerchantList", result);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMerchant(int id)
        {
            var model = await _merchantService.GetByIdAsync(id);
            if (model == null)
            {
                return View("CustomNotFound");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMerchant(MerchantVM merchantVM)
        {
            if (!ModelState.IsValid)
            {
                return View(merchantVM);
            }
            var result = await _merchantService.UpdateAsync(merchantVM);
            if (result)
            {
                return RedirectToAction("MerchantList");
            }
            return View(merchantVM);
        }

        //Branch
        [HttpGet]
        public async Task<IActionResult> BranchList()
        {
            var branches = await _branchService.GetAllAsync();
            var merchants = await _branchService.GetMerchantsSelectListAsync();
            ViewBag.Merchants = merchants;
            return View(branches);
        }

        [HttpPost]
        //create branch
        public async Task<IActionResult> CreateBranch(BranchVM branchVM)
        {
            if (!ModelState.IsValid)
            {
                return View(branchVM);
            }
            // Call the service to create the branch
            await _branchService.CreateAsync(branchVM);
            return RedirectToAction("BranchList");
        }
    }
}
