namespace StreamOr_Web.Areas.Admin.Models
{
    public class AdminDeleteRadioModel
    {
        private string title;

        public AdminDeleteRadioModel()
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

        public string Owner { get; set; }
    }
}
