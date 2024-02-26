using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using static StreamOr.Infrastructure.Constants.ValidationConstants;

namespace StreamOr.Infrastructure.Data.Models
{
	[Comment("Table Radios")]
    public class Radio
    {
        [Key]
        [Comment("Radio Identity")]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(RadioUrlMaxL)]
        [Comment("Radio Url")]
        public string Url { get; set; } = string.Empty;

        [Comment("Radio Title")]
        [AllowNull]
        public string Title { get; set; }

        [Comment("Radio Description")]
        [AllowNull]
        public string Description { get; set; }

        [Required]
        [Comment("Radio Priority")]
        public bool IsFavorite { get; set; }

        [Required]
        [Comment("Date on Adding")]
        public DateTime AddedOn { get; set; }

        [Comment("Radio Logo")]
        [AllowNull]
        public string LogoUrl { get; set; }

        [Comment("Radio Genre")]
        [AllowNull]
        public string Genre { get; set; }

        [Comment("Radio Bitrate")]
        [AllowNull]
        public int Bitrate { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerId))]
        [Comment("Owner Identity")]
        public string OwnerId { get; set; } = string.Empty;
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(GroupId))]
        [Comment("Group Identity")]
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}
