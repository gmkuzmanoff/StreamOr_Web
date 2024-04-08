using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOr.Core.Models.Radio
{
    public class AdminQueryServiceModel
    {
        public int TotalRadiosCount { get; set; }
        public ICollection<RadioViewModel> Radios { get; set; } = new List<RadioViewModel>();
    }
}
