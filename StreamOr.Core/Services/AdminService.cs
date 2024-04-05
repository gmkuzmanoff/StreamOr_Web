using Microsoft.Extensions.Logging;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOr.Core.Services
{
    public class AdminService : IAdminService
    {
        private ILogger<AdminService> logger;
        private readonly StreamorDbContext context;

        public AdminService(StreamorDbContext context, ILogger<AdminService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Task<RadioQueryServiceModel> AllAsync(
            string? group = null, 
            int currentPage = 1, 
            int radiosPerPage = 1,
            string? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}
