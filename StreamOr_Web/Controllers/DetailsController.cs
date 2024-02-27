using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<DetailsController> logger;
        public DetailsController(IRadioService radioService, ILogger<DetailsController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var entity = await radioService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            return View(entity);
        }
    }
}
