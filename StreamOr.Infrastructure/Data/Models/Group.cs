using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StreamOr.Infrastructure.Data.Models
{
    [Comment("Table Groups")]
    public class Group
    {
        [Key]
        [Comment("Group Identity")]
        public int Id { get; set; }

        [Required]
        [Comment("Group Name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Radio> Radios { get; set; } = new List<Radio>();
    }
}
