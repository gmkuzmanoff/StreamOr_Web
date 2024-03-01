using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using System.Security.Claims;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class AddRadioController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<AddRadioController> logger;



        public AddRadioController(IRadioService radioService, ILogger<AddRadioController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

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
            await radioService.AddNewRadioAsync(model, userId);
            return RedirectToAction(nameof(RadioController.Collection), "Radio");
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
