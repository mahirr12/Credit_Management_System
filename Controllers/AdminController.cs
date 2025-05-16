using Microsoft.AspNetCore.Mvc;

namespace Credit_Management_System.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
