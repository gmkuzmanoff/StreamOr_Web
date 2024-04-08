using System.ComponentModel.DataAnnotations;

namespace StreamOr.Core.Models.Radio
{
    public class AllRadiosAdminQueryModel
    {
        [Display(Name = "User")]
        public string? UserTarget { get; set; }

        public int TotalRadiosCount { get; set; }

        public ICollection<string> Users { get; set; } = new List<string>();

        public ICollection<RadioViewModel> Radios { get; set; } = new List<RadioViewModel>();
    }
}
