﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;

namespace StreamOr_Web.Controllers
{
	[Authorize]
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
            var radio = await radioService.DeleteEntityAsync(id);
            if(radio == null) { BadRequest(); }
            return RedirectToAction(nameof(RadioController.Collection),"Radio");
        }
    }
}
