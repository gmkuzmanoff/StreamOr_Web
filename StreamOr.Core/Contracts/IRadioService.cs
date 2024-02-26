using StreamOr.Core.Models;
using StreamOr.Infrastructure.Data.Models;

namespace StreamOr.Core.Contracts
{
    public interface IRadioService
    {
        Task AddNewRadioAsync(RadioFormViewModel model, string userId);
        Task<Radio>  DeleteEntityAsync(string id);
        Task<RadioViewModel> FindTargetAsync(string id);
        Task<ICollection<RadioViewModel>> GetCollectionAsync(string userId);
        Task<ICollection<GroupViewModel>> GetGroupsAsync();
    }
}
