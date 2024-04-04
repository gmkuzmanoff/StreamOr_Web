using Microsoft.AspNetCore.Identity;
using static StreamOr.Infrastructure.Constants.RoleConstants;

namespace StreamOr_Web.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
			{
				var role = new IdentityRole(AdminRole);
				await roleManager.CreateAsync(role);
				var admin = await userManager.FindByNameAsync(AdminEmail);
				if (admin !=  null)
				{
					await userManager.AddToRoleAsync(admin, role.Name);
				}
			}
		}
	}
}
