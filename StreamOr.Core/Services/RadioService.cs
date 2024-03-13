using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using StreamOr.Infrastructure.Data;
using StreamOr.Infrastructure.Data.Models;
using System.Net.Http.Headers;
using System.Net;
using System.Web;
using static StreamOr.Infrastructure.Constants.RadioMetadata;

namespace StreamOr.Core.Services
{
	public class RadioService : IRadioService
	{
        private ILogger<RadioService> logger;
        private readonly StreamorDbContext context;
		public RadioService(StreamorDbContext context, ILogger<RadioService> logger)
		{
			this.context = context;
            this.logger = logger;
		}

        public async Task AddNewRadioAsync(RadioFormViewModel model, string userId)
        {
            var entity = new Radio();
            entity.Id = $"{userId}-{model.Url}";
            entity.Url = model.Url;
            if (string.IsNullOrEmpty(model.Genre))
            {
                model.Genre = await GetGenre(model.Url);
            }
            entity.Genre = model.Genre;
            if (string.IsNullOrEmpty(model.Title))
            {
                model.Title = await GetTitle(model.Url);
            }
            entity.Title = model.Title;
            string br = await GetBitrate(model.Url);
            if (string.IsNullOrEmpty(br))
            {
                br = "128";
            }
            entity.Bitrate = int.Parse(br);
            entity.Description = await GetDescription(model.Url);
            entity.OwnerId = userId;
            entity.IsFavorite = false;
            if (string.IsNullOrEmpty(model.LogoUrl))
            {
                model.LogoUrl = string.Empty;
            }
            entity.LogoUrl = model.LogoUrl;
            entity.GroupId = model.Group;
            entity.AddedOn = DateTime.Now;
            if (!context.Radios.Contains(entity))
            {
                await context.Radios.AddAsync(entity);
            }
            else
            {
                
            }
            
            await context.SaveChangesAsync();
        }

        public async Task EditRadioAsync(RadioFormViewModel model, string userId)
        {
            var entity = await context.Radios.FindAsync(HttpUtility.UrlDecode(model.Id));
			entity.Url = model.Url;
            if (string.IsNullOrEmpty(model.Genre))
            {
                model.Genre = await GetGenre(model.Url);
            }
            entity.Genre = model.Genre;
            if (string.IsNullOrEmpty(model.Title))
            {
                model.Title = await GetTitle(model.Url);
            }
            entity.Title = model.Title;
            string br = await GetBitrate(model.Url);
            if (string.IsNullOrEmpty(br))
            {
                br = "128";
            }
            entity.Bitrate = int.Parse(br);
            entity.Description = await GetDescription(model.Url);
            entity.IsFavorite = false;
            if (string.IsNullOrEmpty(model.LogoUrl))
            {
                model.LogoUrl = string.Empty;
            }
            entity.LogoUrl = model.LogoUrl;
            entity.GroupId = model.Group;
            entity.AddedOn = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<ICollection<RadioViewModel>> GetCollectionAsync(string userId)
        {
			return await context.Radios
				.AsNoTracking()
				.Where(x => x.OwnerId == userId)
				.Select(x => new RadioViewModel()
				{
                    Id = x.Id,
					Title = x.Title,
                    Genre = x.Genre,
                    Description = x.Description,
                    OwnerId = userId,
                    LogoUrl = x.LogoUrl,
					IsFavorite = x.IsFavorite.ToString().ToLower()
				})
				.ToListAsync();
        }

        public async Task<ICollection<GroupViewModel>> GetGroupsAsync()
        {
            return await context.Groups
                .AsNoTracking()
                .Select(x => new GroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
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
                    OwnerId=x.OwnerId,
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

        public async Task<RadioPlayerViewModel> GetPlayerContentAsync(string userId)
        {
            return await context.Radios
                .AsNoTracking()
                .Where(x => x.OwnerId == userId)
                .Select(x => new RadioPlayerViewModel()
                {
                    Id= x.Id,
                    Title = x.Title,
                    Url = x.Url,
                    Genre = x.Genre,
                    Description = x.Description,
                    LogoUrl= x.LogoUrl,
                    IsFavorite = x.IsFavorite.ToString().ToLower(),
                    Bitrate = x.Bitrate.ToString()
                })
                .FirstOrDefaultAsync();
        }

	}
}
