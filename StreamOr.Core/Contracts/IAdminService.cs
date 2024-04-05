using StreamOr.Core.Enumerations;
using StreamOr.Core.Models.Radio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOr.Core.Contracts
{
    public interface IAdminService
    {
        Task<RadioQueryServiceModel> AllAsync(
        string? group = null,
        int currentPage = 1,
        int radiosPerPage = 1,
        string? userId = null);
    }
}
