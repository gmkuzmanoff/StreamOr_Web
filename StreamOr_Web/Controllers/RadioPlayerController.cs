using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Web.Helpers;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using System.Net;
using System.Security.Claims;
using System.Text;

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
            //Create local user html 
            //string localUserFile = $"{localUserDir}\\{userId}.html";
            //StreamWriter writer = new StreamWriter(localUserFile);
            //writer.WriteLine(CreateHtmlPlayer(model.LogoUrl, model.Title, model.Genre, model.Url, model.Bitrate, model.Description));
            //writer.Close();
            //Send html file to ftp
            //string ftpServerAddress = $"ftp://streamor.free.bg/Files/{userId}.html";
            //string fileToUpload = localUserFile;
            //FtpUploadFile(ftpServerAddress, fileToUpload);
            
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

		public string CreateHtmlPlayer(string logo, string title, string genre, string url, string bitrate, string description)
        {
            return $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<style>\r\n    @import url(\"https://fonts.googleapis.com/css?family=Anta\");\r\n    @import url(\"https://fonts.googleapis.com/css2?family=Lato&family=Roboto+Condensed:ital,wght@0,100..900;1,100..900&family=Roboto:ital,wght@0,300;0,400;0,700;1,300&display=swap\");\r\n\r\n    html {{\r\n        font-size: 14px;\r\n    }}\r\n\r\n    @media (min-width: 768px) {{\r\n        html {{\r\n            font-size: 16px;\r\n        }}\r\n    }}\r\n\r\n    html {{\r\n        position: relative;\r\n        min-height: 100%;\r\n    }}\r\n\r\n    body {{\r\n        margin-bottom: 60px;\r\n        background-color: #222222;\r\n    }}\r\n\r\n    #title {{\r\n        font-family: 'Anta';\r\n    }}\r\n\r\n    #title-index {{\r\n        font-family: 'Anta';\r\n        font-size: 90px;\r\n        vertical-align: middle;\r\n        border: 1px solid orange;\r\n        border-radius: 5px;\r\n        padding: 15px;\r\n    }}\r\n\r\n    a,\r\n    button,\r\n    h1,\r\n    h2,\r\n    h3 {{\r\n        font-family: \"Roboto Condensed\", sans-serif;\r\n        font-optical-sizing: auto;\r\n        font-weight: 300;\r\n        font-style: normal;\r\n        text-decoration: none;\r\n        color: darkcyan;\r\n    }}\r\n\r\n    #app-greeting {{\r\n        color: whitesmoke;\r\n        font-size: 19px;\r\n        font-family: \"Roboto Condensed\", sans-serif;\r\n        font-style: italic;\r\n        text-transform: uppercase;\r\n    }}\r\n\r\n    #about-list>li {{\r\n        color: white;\r\n        font-family: \"Roboto Condensed\", sans-serif;\r\n        font-optical-sizing: auto;\r\n    }}\r\n\r\n    .col-md-6,\r\n    h3,\r\n    h4 {{\r\n        color: white;\r\n    }}\r\n\r\n    .col,\r\n    .delete-info>h5,\r\n    h6 {{\r\n        font-family: \"Roboto Condensed\", sans-serif;\r\n        box-shadow: 0 0 1em 0 rgba(0, 0, 0, 0.3);\r\n    }}\r\n\r\n    .card-title,\r\n    #card-genre {{\r\n        white-space: nowrap;\r\n        text-overflow: ellipsis;\r\n        object-fit: contain;\r\n        overflow: hidden;\r\n        line-break: normal;\r\n    }}\r\n</style>\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Player</title>\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\"\r\n        integrity=\"sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH\" crossorigin=\"anonymous\">\r\n</head>\r\n\r\n<body>\r\n    <header b-59i2a63ekl>\r\n        <nav b-59i2a63ekl\r\n            class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light border-bottom border-warning bg-black box-shadow mb-3\">\r\n            <div b-59i2a63ekl class=\"container-fluid\">\r\n                <a id=\"title\" class=\"navbar-brand text-warning fs-2 mx-2\">StreamOr</a>\r\n            </div>\r\n        </nav>\r\n    </header>\r\n    <div b-59i2a63ekl class=\"container\">\r\n        <main b-59i2a63ekl role=\"main\" class=\"pb-3\">\r\n            <h1 class=\"text-success\">Radio Player</h1>\r\n            <br />\r\n            <br />\r\n            <body class=\"bg-dark\">\r\n                <div class=\"card mb-3\">\r\n                    <div class=\"row g-0\">\r\n                        <div class=\"col-md-4\">\r\n                            <img src=\"{logo}\" class=\"img-fluid rounded-start\" alt=\"...\">\r\n                        </div>\r\n                        <div class=\"col-md-8\">\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title fs-2\">{title}</h5>\r\n                                <p class=\"card-text fs-4\">{genre}</p>\r\n                                <p class=\"card-text\"><small class=\"text-body-secondary\">{description}</small></p>\r\n                                <p class=\"card-text\">{bitrate}<small class=\"text-body-secondary\"> Kbps</small></p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"card-footer d-flex justify-content-between\">\r\n                            <audio class=\"w-100\" src=\"{url}\" controls autoplay></audio>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </body>\r\n        </main>\r\n</html>\r\n\r\n<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz\" crossorigin=\"anonymous\"></script>";
        }

        public void FtpUploadFile(string ftpServerAddress, string fileToUpload)
        {
            WebClient webClient = new WebClient();
            string username = "streamor.free.bg";
            string password = "";
            webClient.Credentials = new NetworkCredential(username, password);
            webClient.UploadFile(ftpServerAddress, fileToUpload);
        }
	}

    
}
