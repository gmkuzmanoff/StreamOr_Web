﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;

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
        public async Task<IActionResult> GetPlayModel(string id)
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
                OwnerId = entity.OwnerId,
                Group = entity.Group.Name,
                IsFavorite = entity.IsFavorite.ToString().ToLower(),
                Bitrate = entity.Bitrate.ToString()
            };
            //Create local user directory
            string localUserDir = $"{Environment.CurrentDirectory}\\files\\{userId}";
            Directory.CreateDirectory(localUserDir);

            return View(model);
        }
        
        public IActionResult PlayInNewTab(string url)
        {
            return Redirect(url);
        }

        [HttpGet]
        public async Task<FileResult> GetPlaylist(string id)
        {
            string userId = GetUserId();
            var entity = await radioService.FindTargetAsync(id);
            if (entity == null)
            {
                //return BadRequest();
            }
            var model = new RadioPlayerViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Url = entity.Url,
                Genre = entity.Genre,
                Description = entity.Description,
                LogoUrl = entity.LogoUrl,
                OwnerId = entity.OwnerId,
                Group = entity.Group.Name,
                IsFavorite = entity.IsFavorite.ToString().ToLower(),
                Bitrate = entity.Bitrate.ToString()
            };
            //Create local user directory
            string localUserDir = $"{Environment.CurrentDirectory}\\files\\{userId}";
            //Create local user html 
            string localUserFile = $"{localUserDir}\\{userId}.m3u";
            StreamWriter writer = new StreamWriter(localUserFile);
            writer.WriteLine(CreateM3uPlaylist(model.Url, model.Title, model.Group, model.LogoUrl));
            writer.Close();
            return PhysicalFile(localUserFile, "application/m3u", $"{model.Title}.m3u");
        }

        [HttpPost]
        public async Task<IActionResult> EditIsFavorite(RadioPlayerViewModel model)
        {
            string userId = GetUserId();

            var entity = await radioService.FindTargetAsync(model.Id);

            if (entity == null)
            {
               return BadRequest();
            }

            await radioService.EditIsFavoriteAsync(model, userId);
            return RedirectToAction(nameof(GetPlayModel), new {id=model.Id});
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        public string CreateM3uPlaylist(string url, string title, string group, string logo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("#EXTM3U");
            stringBuilder.AppendLine($"#EXTINF:-1 group-title=\"{group}\" tvg-logo=\"{logo}\", {title}");
            stringBuilder.AppendLine(url);
            return stringBuilder.ToString();
        }
    }

    
}
