using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamOr.Core.Contracts;
using StreamOr_Web.Areas.Admin.Models;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private ILogger<AdminController> logger;

        public AdminController(
            IAdminService adminService,
            ILogger<AdminController> logger)
        {
            this.adminService = adminService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Wall([FromQuery] AllRadiosAdminQueryModel query)
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated && User.IsInRole(AdminRole))
            {
                var model = await adminService.AllAsync(
                    query.UserTarget
                    );

                query.Radios = model.Radios;
                query.TotalRadiosCount = model.TotalRadiosCount;
                query.Users = await adminService.AllUsernamesAsync();
                return View(query);
            }
            return Unauthorized();
        }
    }
}
