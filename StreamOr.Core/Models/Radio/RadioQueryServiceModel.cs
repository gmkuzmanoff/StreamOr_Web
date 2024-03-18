namespace StreamOr.Core.Models.Radio
{
    public class RadioQueryServiceModel
    {
        public int TotalRadiosCount { get; set; }
        public ICollection<RadioViewModel> Radios { get; set; } = new List<RadioViewModel>();
    }
}
