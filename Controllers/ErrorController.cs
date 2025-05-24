using Microsoft.AspNetCore.Mvc;

namespace Credit_Management_System.Controllers
{
    
    public class ErrorController : Controller
    {
        public IActionResult CustomNotFound()
        {
            return View();
        }
    }
}
