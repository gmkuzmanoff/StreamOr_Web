using StreamOr.Core.Models.Radio;

namespace TestProject
{
    [TestFixture]
    public class RadioDeleteViewModelTests
    {
        private RadioDeleteViewModel model;

        [SetUp]
        public void Setup()
        {
            model = new RadioDeleteViewModel();
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

        [TearDown]
        public void Teardown()
        {
            model = null!;
        }
    }
}
