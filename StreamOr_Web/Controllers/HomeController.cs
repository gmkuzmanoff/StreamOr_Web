using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated && !User.IsInRole(AdminRole))
            {
                return RedirectToAction("Collection", "Radio");
            }
            else if(User?.Identity != null && User.Identity.IsAuthenticated && User.IsInRole(AdminRole))
            {
                return RedirectToAction("Wall", "Admin", new {Area="Admin"});
            }
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
			if (statusCode == 404)
			{
				return View("Error404");
			}
			if (statusCode == 500)
			{
				return View("Error500");
			}

			return View();
        }

    }
}
