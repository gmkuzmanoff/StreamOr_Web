using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOr.Core.Models
{
    public class RadioDetailsViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string IsFavorite { get; set; } = string.Empty;

        public string AddedOn { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Bitrate { get; set; } = string.Empty;

        public string Group { get; set; } = string.Empty;
    }
}
