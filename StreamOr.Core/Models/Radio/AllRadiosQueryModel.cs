using StreamOr.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace StreamOr.Core.Models.Radio
{
    public class AllRadiosQueryModel
    {
        public int RadiosPerPage { get; } = 10;

        public string? Group { get; set; }

        [Display(Name = "Search Term")]
        public string? SearchTerm { get; set; }

        public RadiosSorting Sorting { get; set; }

        [Display(Name = "Current Page")]
        public int CurrentPage { get; set; } = 1;

        public ICollection<string> Groups { get; set; } = new List<string>();

        public ICollection<RadioViewModel> Houses { get; set; } = new List<RadioViewModel>();
    }
}
