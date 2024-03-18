using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using System.Security.Claims;

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
		
		[HttpGet]
		public async Task<IActionResult> Collection([FromQuery]AllRadiosQueryModel query)
		{ 
			string userId = GetUserId();
            var model = await radioService.AllAsync(
                query.Group,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.RadiosPerPage,
                userId
                );

            query.Radios = model.Radios;
            query.TotalRadiosCount = model.TotalRadiosCount;
            query.Groups = await radioService.AllGroupsNamesAsync();
            return View(query);
		}

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
