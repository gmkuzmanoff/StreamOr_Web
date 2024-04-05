using StreamOr.Core.Enumerations;
using StreamOr.Core.Models.Radio;
using StreamOr.Infrastructure.Data.Models;

namespace StreamOr.Core.Contracts
{
    public interface IRadioService
    {
        Task AddNewRadioAsync(RadioFormViewModel model, string userId);
        Task EditRadioAsync(RadioFormViewModel model, string userId);
        Task<Radio> DeleteEntityAsync(string id);
        Task<Radio> FindTargetAsync(string id);
        Task<RadioPlayerViewModel> GetPlayerContentAsync(string userId);
        Task<ICollection<GroupViewModel>> GetGroupsAsync();
        Task EditIsFavoriteAsync(RadioPlayerViewModel model, string userId);
        Task<RadioQueryServiceModel> AllAsync(
        string? group = null,
        string? searchTerm = null,
        RadiosSorting sorting = RadiosSorting.Default,
        int currentPage = 1,
        int radiosPerPage = 1,
        string? userId = null);
        Task<ICollection<string>> AllGroupsNamesAsync();
        Task<string> GetStreamTitle(string url);
    }
}
