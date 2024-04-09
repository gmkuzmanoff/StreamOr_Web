using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Data;
using StreamOr.Infrastructure.Data.Models;
using System.Web;

namespace StreamOr.Core.Services
{
    public class AdminService : IAdminService
    {
        private ILogger<AdminService> logger;
        private readonly StreamorDbContext context;

        public AdminService(
            StreamorDbContext context,
            ILogger<AdminService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Radio> FindTargetAsync(string id)
        {
            return await context.Radios
                .AsNoTracking()
                .Select(x => new Radio()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Url = x.Url,
                    Genre = x.Genre,
                    OwnerId = x.OwnerId,
                    Owner = x.Owner,
                    Description = x.Description,
                    IsFavorite = x.IsFavorite,
                    AddedOn = x.AddedOn,
                    LogoUrl = x.LogoUrl,
                    Group = x.Group,
                    Bitrate = x.Bitrate
                })
                .FirstOrDefaultAsync(x => x.Id == HttpUtility.UrlDecode(id));
        }

        public async Task<AdminQueryServiceModel> AllAsync(
            string? user = null)
        {
            var radiosToShow = context.Radios
                .AsNoTracking();

            if (user != null)
            {
                radiosToShow = radiosToShow.Where(x => x.Owner.UserName == user);
            }

            var radios = await radiosToShow
                .Select(x => new RadioViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Genre = x.Genre,
                    Description = x.Description,
                    OwnerId = x.OwnerId,
                    LogoUrl = x.LogoUrl,
                    IsFavorite = x.IsFavorite.ToString().ToLower()
                })
                .ToListAsync();

            int radiosCount = await radiosToShow.CountAsync();

            return new AdminQueryServiceModel()
            {
                TotalRadiosCount = radiosCount,
                Radios = radios
            };
        }

        public async Task<ICollection<string>> AllUsernamesAsync()
        {
            return await context.Users
                .AsNoTracking()
                .Select(x => x.UserName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Radio> DeleteEntityAsync(string id)
        {
            var radio = await context.Radios.FindAsync(HttpUtility.UrlDecode(id));
            if (radio != null)
            {
                context.Radios.Remove(radio);
                await context.SaveChangesAsync();
            }
            return radio;
        }
    }
}
