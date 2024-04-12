using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StreamOr.Core.Contracts;
using StreamOr.Core.Enumerations;
using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Data;
using StreamOr.Infrastructure.Data.Models;
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
            if (entity != null)
            {
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

        public async Task<Radio?> FindTargetAsync(string id)
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
                .Where(x => x.Id == HttpUtility.UrlDecode(id))
                .FirstOrDefaultAsync();
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

        public async Task EditIsFavoriteAsync(RadioPlayerViewModel model, string userId)
        {
            var entity = await context.Radios.FindAsync(HttpUtility.UrlDecode(model.Id));
            if (entity != null)
            {
                if (entity.IsFavorite)
                {
                    entity.IsFavorite = false;
                }
                else { entity.IsFavorite = true; }
            }
            
            await context.SaveChangesAsync();
        }

        public async Task<RadioQueryServiceModel> AllAsync(
            string? group = null,
            string? searchTerm = null,
            RadiosSorting sorting = RadiosSorting.Default,
            int currentPage = 1,
            int radiosPerPage = 1,
            string? userId = null)
        {
            var radiosToShow = context.Radios
                .AsNoTracking()
                .Where(x => x.OwnerId == userId);

            if (group != null)
            {
                radiosToShow = radiosToShow.Where(x => x.Group.Name == group);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                radiosToShow = radiosToShow
                    .Where(
                    x => x.Title.ToLower().Contains(normalizedSearchTerm) ||
                    x.Genre.ToLower().Contains(normalizedSearchTerm));
            }

            radiosToShow = sorting switch
            {
                RadiosSorting.Ascending => radiosToShow.OrderBy(x => x.Title),
                RadiosSorting.Descending => radiosToShow.OrderByDescending(x => x.Title),
                RadiosSorting.Favorites => radiosToShow.OrderByDescending(x => x.IsFavorite).ThenBy(x => x.Title),
                RadiosSorting.Default => radiosToShow
            };

            var radios = await radiosToShow
                .Skip((currentPage - 1) * radiosPerPage)
                .Take(radiosPerPage)
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

            int radiosCount = await radiosToShow.CountAsync();

            return new RadioQueryServiceModel()
            {
                TotalRadiosCount = radiosCount,
                Radios = radios
            };

        }

        public async Task<ICollection<string>> AllGroupsNamesAsync()
        {
            return await context.Groups
                .AsNoTracking()
                .Select(x => x.Name)
                .Distinct()
                .ToListAsync();  
        }

        public async Task<string> GetStreamTitle(string url)
        {
            string nowPlayingSong = "";
            nowPlayingSong = await GetNowPlayingTitleFromShoutcastServer(url);

            if (string.IsNullOrEmpty(nowPlayingSong))
            {
                string metadata = await GetMetaDataFromIceCastStream(url);
                try
                {
                    nowPlayingSong = metadata.Split('=')[1].Replace("'", "").Replace(";", "");
                }
                catch
                {
                    nowPlayingSong = "There is no information about current title";
                }
            }
            return nowPlayingSong.Trim().Replace("StreamUrl", "");
        }

    }
}
