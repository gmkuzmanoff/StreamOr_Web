using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using System.Security.Claims;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class RadioPlayerController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<RadioPlayerController> logger;

        public RadioPlayerController(IRadioService radioService, ILogger<RadioPlayerController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Play(string id)
        {
            string userId = GetUserId();
			var entity = await radioService.FindTargetAsync(id);

			if (entity == null)
			{
				return BadRequest();
			}

            var model = new RadioPlayerViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Url = entity.Url,
                Genre = entity.Genre,
                Description = entity.Description,
                LogoUrl = entity.LogoUrl,
                IsFavorite = entity.IsFavorite.ToString().ToLower(),
                Bitrate = entity.Bitrate.ToString()
            };
			return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
