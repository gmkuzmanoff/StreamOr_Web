using StreamOr.Core.Models.Radio;

namespace TestProject
{
    [TestFixture]
    public class RadioDetailsViewModelTests
    {
        private RadioDetailsViewModel model;

        [SetUp]
        public void Setup()
        {
            model = new RadioDetailsViewModel();
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
