namespace StreamOr.Core.Models
{
    public class RadioDetailsViewModel
    {
        private string title;
        private string genre;
        private string description;

        public RadioDetailsViewModel()
        {

        }

        public string Id { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = $"Unknown title";
                }
                title = value;
            }
        }

        public string IsFavorite { get; set; } = string.Empty;

        public string AddedOn { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public string Bitrate { get; set; } = string.Empty;

        public string Group { get; set; } = string.Empty;

        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = $"various";
                }
                genre = value;
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = $"The best {genre} music in the world!";
                }
                description = value;
            }
        }
    }
}
