﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using System.Security.Claims;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    [Route("details")]
    public class DetailsRadioController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<DetailsRadioController> logger;

        public DetailsRadioController(IRadioService radioService, ILogger<DetailsRadioController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Details(RadioDetailsViewModel model, string id)
        {
            string userId = GetUserId();
            var entity = await radioService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            else if (entity.OwnerId != userId && !User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }

            model.Title = entity.Title;
            model.Genre = entity.Genre;
            model.Description = entity.Description;
            model.AddedOn = entity.AddedOn.ToLongDateString();
            model.Bitrate = entity.Bitrate.ToString();
            model.Group = entity.Group.Name;
            model.IsFavorite = entity.IsFavorite.ToString();
            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
