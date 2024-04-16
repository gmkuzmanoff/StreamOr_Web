using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Constants;
using System.Globalization;
using System.Security.Claims;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    [Route("edit/{id}")]
    public class EditRadioController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<EditRadioController> logger;

        public EditRadioController(IRadioService radioService, ILogger<EditRadioController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            string userId = GetUserId();
            var entity = await radioService.FindTargetAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }
            else if (entity.OwnerId != userId)
            {
                return Unauthorized();
            }
            var model = new RadioFormViewModel()
            {
                Id = entity.Id,
                Url = entity.Url,
                Title = entity.Title,
                Genre = entity.Genre,
                Description = entity.Description,
                LogoUrl = entity.LogoUrl,
                Group = entity.Group.Id
            };

            model.Groups = await radioService.GetGroupsAsync();
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(RadioFormViewModel model)
        {
            string userId = GetUserId();

            if (!ModelState.IsValid)
            {
                model.Groups = await radioService.GetGroupsAsync();
                return View(model);
            }

            var entity = await radioService.FindTargetAsync(model.Id);

            if (entity == null)
            {
                return BadRequest();
            }

            await radioService.EditRadioAsync(model, userId);
            return RedirectToAction(nameof(Collection), "Radio");
        }

		private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}
	}
}
