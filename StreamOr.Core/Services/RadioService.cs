using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models;
using StreamOr.Infrastructure.Data;
using StreamOr.Infrastructure.Data.Models;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;

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
					Description = x.Description,
					Genre = x.Genre,
					LogoUrl = x.LogoUrl,
                    AddedOn = x.AddedOn.ToShortDateString(),
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

        public async Task<RadioViewModel> FindTargetAsync(string id)
        {
            return await context.Radios
                .AsNoTracking()
                .Select(x => new RadioViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Url = x.Url,
                    Description = x.Description,
                    IsFavorite = x.IsFavorite.ToString(),
                    Genre = x.Genre,
                    AddedOn = x.AddedOn.ToShortDateString(),
                    LogoUrl = x.LogoUrl,
                    Group = x.Group.Name
                })
                .FirstOrDefaultAsync(x => x.Id == HttpUtility.UrlDecode(id));
        }

        public async Task<Radio> DeleteEntityAsync(string id)
        {
            var radio = await context.Radios.FindAsync(HttpUtility.UrlDecode(id));
            context.Radios.Remove(radio);
            await context.SaveChangesAsync();
            return radio;
        }
        /// <summary>
        /// Get Title from metadata
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetTitle(string uri)
        {
            string result = "";
            HttpClient m_httpClient = new HttpClient();
            HttpResponseMessage response = null;
            m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
            try
            {
                response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<string> headerValues;
                    if (response.Headers.TryGetValues("icy-name", out headerValues))
                    {
                        string metaIntString = headerValues.First();
                        if (!string.IsNullOrEmpty(metaIntString))
                        {
                            result = metaIntString;
                        }

                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }
            m_httpClient.Dispose();
            return result;
        }
        /// <summary>
        /// Get Genre from metadata
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetGenre(string uri)
        {
            string result = "";
            HttpClient m_httpClient = new HttpClient();
            HttpResponseMessage response = null;
            m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
            try
            {
                response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<string> headerValues;
                    if (response.Headers.TryGetValues("icy-genre", out headerValues))
                    {
                        string metaIntString = headerValues.First();
                        if (!string.IsNullOrEmpty(metaIntString))
                        {
                            result = metaIntString;
                        }

                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }
            m_httpClient.Dispose();
            return result;
        }
        /// <summary>
        /// Get Bitrate from metadata
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetBitrate(string uri)
        {
            string result = "";
            HttpClient m_httpClient = new HttpClient();
            HttpResponseMessage response = null;
            m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
            try
            {
                response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<string> headerValues;
                    if (response.Headers.TryGetValues("icy-br", out headerValues))
                    {
                        string metaIntString = headerValues.First();
                        if (!string.IsNullOrEmpty(metaIntString))
                        {
                            result = metaIntString;
                        }

                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }
            m_httpClient.Dispose();
            return result;
        }
        /// <summary>
        /// Get Description from metadata
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetDescription(string uri)
        {
            string result = "";
            HttpClient m_httpClient = new HttpClient();
            HttpResponseMessage response = null;
            m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
            try
            {
                response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<string> headerValues;
                    if (response.Headers.TryGetValues("icy-description", out headerValues))
                    {
                        string metaIntString = headerValues.First();
                        if (!string.IsNullOrEmpty(metaIntString))
                        {
                            result = metaIntString;
                        }

                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }
            m_httpClient.Dispose();
            return result;
        }

        
    }
}
