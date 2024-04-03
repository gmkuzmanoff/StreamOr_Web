﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using System.Security.Claims;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class DeleteRadioController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<DeleteRadioController> logger;
        public DeleteRadioController(
            IRadioService radioService, 
            ILogger<DeleteRadioController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(RadioDeleteViewModel model, string id)
        {
            var entity = await radioService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            model.Title = entity.Title;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var radio = await radioService.DeleteEntityAsync(id);
            if (radio == null)
            {
                return BadRequest();
            }
            else if (radio.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            return RedirectToAction(nameof(RadioController.Collection),"Radio");
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
