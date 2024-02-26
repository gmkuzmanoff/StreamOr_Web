using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StreamOr.Core.Contracts;
using StreamOr.Core.Services;

namespace StreamOr_Web.Controllers
{
    public class DeleteRadioController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<RadioController> logger;
        public DeleteRadioController(IRadioService radioService, ILogger<RadioController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await radioService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            logger.LogInformation($"RADIO ID: {id}");
            await radioService.DeleteEntityAsync(id);
            return RedirectToAction(nameof(RadioController.Collection),"Radio");
        }
    }
}
