using StreamOr.Core.Models.Radio;

namespace StreamOr.Core.Contracts
{
    public interface IAdminService
    {
        Task<AdminQueryServiceModel> AllAsync(
        string? user = null);
        Task<ICollection<string>> AllUsernamesAsync();
    }
}
