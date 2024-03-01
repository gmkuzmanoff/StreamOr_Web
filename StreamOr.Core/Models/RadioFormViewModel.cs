using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static StreamOr.Infrastructure.Constants.ValidationConstants;

namespace StreamOr.Core.Models
{
    public class RadioFormViewModel
    {

        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(RadioUrlMaxL, MinimumLength = RadioUrlMinL, ErrorMessage = StringLengthErrorMessage)]
        [DisplayName("Radio URL")]
        public string Url { get; set; } = string.Empty;
        
        public string? Title {  get; set; }

        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        public string? Genre { get; set; }

        public bool IsFavorite { get; set; }

        public string? Bitrate { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int Group { get; set; }

        public ICollection<GroupViewModel> Groups { get; set; } = new List<GroupViewModel>();

    }


}
