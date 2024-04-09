using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr_Web.Areas.Admin.Models;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area(AdminAreaName)]
    public class AdminDeleteController : Controller
    {
        private readonly IAdminService adminService;
        private ILogger<AdminDeleteController> logger;

        public AdminDeleteController(IAdminService adminService, ILogger<AdminDeleteController> logger)
        {
            this.adminService = adminService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(AdminDeleteRadioModel model, string id)
        {
            var entity = await adminService.FindTargetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            if (!User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }
            model.Title = entity.Title;
            model.Owner = entity.Owner.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var target = await adminService.FindTargetAsync(id);
            if (!User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }
            var radio = await adminService.DeleteEntityAsync(id);
            return RedirectToAction(nameof(AdminController.Wall), "Admin");
        }
    }
}
