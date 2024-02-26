﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly StreamorDbContext context;
        private ILogger<RadioController> logger;
		public RadioController(StreamorDbContext context,IRadioService radioService, ILogger<RadioController> logger)
		{
            this.context = context;
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
        //Delete
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
            return RedirectToAction(nameof(Collection));
        }


        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        
    }
}