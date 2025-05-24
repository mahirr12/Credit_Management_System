using Credit_Management_System.Models;
using Credit_Management_System.Services.Implementations;
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
        private readonly IEmployeeService _employeeService;

        public AdminController(IMerchantService merchantService, IBranchService branchService, IEmployeeService employeeService)
        {
            _merchantService = merchantService;
            _branchService = branchService;
            _employeeService = employeeService;
        }

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
                return NotFound();
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
        [HttpGet]
        public async Task<IActionResult> CreateBranch()
        {

            var model = new BranchVM() { Merchants = await _branchService.GetMerchantsSelectListAsync() };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(BranchVM branchVM)
        {
            if (!ModelState.IsValid)
            {
                return View(branchVM);
            }

            try
            {
                await _branchService.CreateAsync(branchVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("MerchantId", ex.Message);
                branchVM.Merchants = await _branchService.GetMerchantsSelectListAsync();
                return View(branchVM);
            }


            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBranch(int id)
        {
            var model = await _branchService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var merchants = await _branchService.GetMerchantsSelectListAsync();
            ViewBag.Merchants = merchants;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBranch(BranchVM branchVM)
        {
            if (!ModelState.IsValid)
            {
                var merchantsList = await _branchService.GetMerchantsSelectListAsync();
                ViewBag.Merchants = merchantsList;
                return View(branchVM);
            }
            var result = await _branchService.UpdateAsync(branchVM);
            if (result)
            {
                return RedirectToAction("BranchList");
            }
            var merchants = await _branchService.GetMerchantsSelectListAsync();
            ViewBag.Merchants = merchants;
            return View(branchVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var result = await _branchService.DeleteAsync(id);
            return RedirectToAction("BranchList", result);
        }

        //Employee
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var employees = await _employeeService.GetAllAsync();
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = branches;
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            var model = new EmployeeVM() { Branches = await _branchService.GetBranchesSelectListAsync() };  
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Branches = await _branchService.GetBranchesSelectListAsync();

                return View(model);
            }
            await _employeeService.CreateAsync(model);
            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(string id)
        {
            var model = await _employeeService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = branches;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeVM model)
        {
            if (!ModelState.IsValid)
            {
                var branchesList = await _branchService.GetAllAsync();
                ViewBag.Branches = branchesList;
                return View(model);
            }
            var result = await _employeeService.UpdateAsync(model);
            if (result)
            {
                return RedirectToAction("EmployeeList");
            }
            var branches = await _branchService.GetAllAsync();
            ViewBag.Branches = branches;
            return View(model);
        }
    }
}
