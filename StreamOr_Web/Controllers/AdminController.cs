using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Wall()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated && User.IsInRole(AdminRole)) 
            {
                return View();
            }
            return Unauthorized();
        }
    }
}
