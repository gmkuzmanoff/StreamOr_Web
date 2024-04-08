using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamOr.Core.Contracts;
using StreamOr.Core.Services;
using StreamOr.Infrastructure.Data;
using StreamOr_Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StreamorDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StreamorDbContext>();
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });
// Add services to the container.
builder.Services.AddScoped<IRadioService, RadioService>();
builder.Services.AddScoped<IAdminService, AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

await app.CreateAdminRoleAsync();

app.Run();
