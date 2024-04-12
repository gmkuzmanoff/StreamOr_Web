using StreamOr.Core.Models.Radio;

namespace TestProject
{
    [TestFixture]
    public class RadioPlayerViewModelTests
    {
        private RadioPlayerViewModel model;
        private string[] images;

        [SetUp]
        public void Setup()
        {
            model = new RadioPlayerViewModel();
            images = new[] { "https://gmkuzmanoff.free.bg/images/STREAMOR/P1.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P2.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P3.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P4.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P5.jpg",
                "https://gmkuzmanoff.free.bg/images/STREAMOR/P6.jpg"};
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Title(string title)
        {
            model.Title = title;
            Assert.That(model.Title, Is.EqualTo("Unknown title"),
                $"Model title != {model.Title}!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_LogoUrl(string logoUrl)
        {
            model.LogoUrl = logoUrl;
            Assert.That(model.LogoUrl, Is.AnyOf(images),
                "Model logo is empty!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Genre(string genre)
        {
            model.Genre = genre;
            Assert.That(model.Genre, Is.EqualTo("various"),
                $"Model genre != {model.Genre}!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Description(string description)
        {
            model.Genre = "";
            model.Description = description;
            Assert.That(model.Description, Is.EqualTo($"The best {model.Genre} music in the world!"),
                $"Model description != The best {model.Genre} music in the world!");
        }

        [TearDown]
        public void Teardown()
        {
            model = null!;
        }
    }
}
