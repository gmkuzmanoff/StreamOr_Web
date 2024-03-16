using System.ComponentModel.DataAnnotations;

namespace StreamOr.Core.Enumerations
{
    public enum RadiosSorting
    {
        Default = 0,

        [Display(Name = "A - Z")]
        Ascending = 1,

        [Display(Name = "Z - A")]
        Descending = 2
    }
}
