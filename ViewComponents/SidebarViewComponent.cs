using Credit_Management_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credit_Management_System.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public SidebarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                // Handle the case where the user is null (e.g., return an empty view or an error view)
                return View("Default", new List<string>()); // Return an empty list of roles
            }

            var roles = await _userManager.GetRolesAsync(user);

            return View("Default", roles);
        }
    }
}
