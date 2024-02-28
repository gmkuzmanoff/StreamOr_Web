namespace StreamOr.Core.Models
{
    public class RadioViewModel
	{
        private string title;
        private string genre;
        private string logoUrl;
        private string description;

        public RadioViewModel()
        {

        }

        public string Id { get; set; } = string.Empty;

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
        
        public string LogoUrl
        {
            get => logoUrl;
            set
            {
                string[] images = { "https://gmkuzmanoff.free.bg/images/STREAMOR/P1.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P2.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P3.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P4.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P5.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P6.jpg"};
                int random = new Random().Next(0, 5);
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = images[random];
                }
                logoUrl = value;
            }
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "various";
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
                    value = $"The best {Genre} music in the world!";
                }
                description = value;
            }
        }
    }
}
