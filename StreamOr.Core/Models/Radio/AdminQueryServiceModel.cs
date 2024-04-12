namespace StreamOr.Core.Models.Radio
{
    public class AdminQueryServiceModel
    {
        public int TotalRadiosCount { get; set; }
        public ICollection<RadioViewModel> Radios { get; set; } = new List<RadioViewModel>();
    }
}
