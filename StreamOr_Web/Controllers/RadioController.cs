using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using StreamOr.Infrastructure.Data;
using StreamOr.Infrastructure.Data.Models;
using System.Security.Claims;
using System.Web;

namespace StreamOr_Web.Controllers
{
	[Authorize]
	public class RadioController : Controller
	{
		private readonly IRadioService radioService;
        private ILogger<RadioController> logger;
		public RadioController(IRadioService radioService, ILogger<RadioController> logger)
		{
			this.radioService = radioService;
            this.logger = logger;
		}
		//Get Collection
		[HttpGet]
		public async Task<IActionResult> Collection()
		{
			string userId = GetUserId();
            ICollection<RadioViewModel> model = await radioService.GetCollectionAsync(userId);
            return View(model);
		}
		//Add radio
		[HttpGet]
        public async Task<IActionResult> Add()
		{
            var model = new RadioFormViewModel();
			model.Groups = await radioService.GetGroupsAsync();
            return View(model);
        }
		[HttpPost]
        public async Task<IActionResult> Add(RadioFormViewModel model)
		{
            string userId = GetUserId();
            if (!ModelState.IsValid)
            {
                model.Groups = await radioService.GetGroupsAsync();
                return View(model);
            }
            await radioService.AddNewRadioAsync(model,userId);
            return RedirectToAction(nameof(Collection));
        }
        


        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        
    }
}
