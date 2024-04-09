using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Data.Models;

namespace StreamOr.Core.Contracts
{
    public interface IAdminService
    {
        Task<AdminQueryServiceModel> AllAsync(
        string? user = null);
        Task<ICollection<string>> AllUsernamesAsync();
        Task<Radio> DeleteEntityAsync(string id);
        Task<Radio> FindTargetAsync(string id);
    }
}
