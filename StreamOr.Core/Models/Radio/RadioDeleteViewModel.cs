namespace StreamOr.Core.Models.Radio
{
    public class RadioDeleteViewModel
    {
        private string title;

        public RadioDeleteViewModel()
        {
        }


        public string Id { get; set; }

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
    }
}
