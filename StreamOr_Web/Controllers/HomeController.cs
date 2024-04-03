using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using StreamOr_Web.Models;
using System.Diagnostics;

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
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Collection", "Radio");
            }
            return View();
        }

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
