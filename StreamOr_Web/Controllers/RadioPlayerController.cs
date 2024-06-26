﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using System.Security.Claims;
using System.Text;

namespace StreamOr_Web.Controllers
{
    [Authorize]
    public class RadioPlayerController : Controller
    {
        private readonly IRadioService radioService;
        private ILogger<RadioPlayerController> logger;

        public RadioPlayerController(
            IRadioService radioService, 
            ILogger<RadioPlayerController> logger)
        {
            this.radioService = radioService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("play/{id}")]
        public async Task<IActionResult> Play(string id)
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
            var model = radioService.RadioForPlayer(entity);
            //Create local user directory if not exist already
            string localUserDir = $"{Environment.CurrentDirectory}\\files\\{userId}";
            Directory.CreateDirectory(localUserDir);

            return View(model);
        }

        [Route("play_in_new_tab")]
        public IActionResult PlayInNewTab(string url)
        {
            return Redirect(url);
        }

        [HttpGet]
        [Route("download_m3u")]
        public async Task<FileResult> GetPlaylist(string id)
        {
            string userId = GetUserId();
            var entity = await radioService.FindTargetAsync(id);
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

            string localUserDir = string.Empty;
            string localUserFile = string.Empty;

            //Create local user directory
            localUserDir = $"{Environment.CurrentDirectory}\\files\\{userId}";
            //Create local user m3u file
            localUserFile = $"{localUserDir}\\{userId}.m3u";
            StreamWriter writer = new StreamWriter(localUserFile);

            if (entity != null && entity.OwnerId == userId)
            {
                writer.WriteLine(CreateM3uPlaylist(model.Url, model.Title, model.Group, model.LogoUrl));
                writer.Close();
                return PhysicalFile(localUserFile, "application/m3u", $"{model.Title}.m3u");
            }

            writer.WriteLine("Status Code 401 \nUnauthorized");
            writer.Close();
            return PhysicalFile(localUserFile, "application/txt", "Unauthorized.txt");
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
            else if (entity.OwnerId != userId)
            {
                return Unauthorized();
            }
            await radioService.EditIsFavoriteAsync(model, userId);
            return RedirectToAction(nameof(Play), new {id=model.Id});
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
