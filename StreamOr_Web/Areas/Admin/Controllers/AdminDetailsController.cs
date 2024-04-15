using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area(AdminAreaName)]
    [Route("admin/details")]
    public class AdminDetailsController : Controller
    {
        private readonly IAdminService adminService;
        private ILogger<AdminDetailsController> logger;

        public AdminDetailsController(IAdminService adminService, ILogger<AdminDetailsController> logger)
        {
            this.adminService = adminService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Details(RadioDetailsViewModel model, string id)
        {
            var entity = await adminService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            else if (!User.IsInRole(AdminRole))
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

    }
}
