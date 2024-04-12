using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using StreamOr.Core.Contracts;
using StreamOr.Core.Models.Radio;
using StreamOr.Core.Services;
using StreamOr.Infrastructure.Data;

namespace TestProject
{
    [TestFixture]
    public class RadioServiceTests
    {
        private IRadioService radioService;
        private ILogger<RadioService> logger;
        private StreamorDbContext context;
        private RadioFormViewModel radioFormViewModel;
        private RadioPlayerViewModel radioPlayerViewModel;
        private string userId;
        private string targetRadioId;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<StreamorDbContext>()
                .UseInMemoryDatabase("RadioDB")
                .Options;
            context = new StreamorDbContext(contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var loggerMock = new Mock<ILogger<RadioService>>();
            logger = loggerMock.Object;
            radioService = new RadioService(context, logger);

            userId = "userid";

            radioFormViewModel = new RadioFormViewModel()
            {
                Title = "Radio",
                Url = "http://radio.stream",
                IsFavorite = false,
                Bitrate = 128.ToString(),
                Group = 1
            };

            targetRadioId = $"{userId}-{radioFormViewModel.Url}";
            
            radioPlayerViewModel = new RadioPlayerViewModel()
            {
                Id = targetRadioId,
                IsFavorite = false.ToString()
            };
        }

        [Test]
        public async Task Test_AddNewRadio()
        {
            int radiosCountBeforeAdd = context.Radios.Count();
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            Assert.IsTrue(context.Radios.Any(x => x.Id == targetRadioId),
                "There is no entity in database with this Id!");
            Assert.That(context.Radios.Count(),Is.EqualTo(radiosCountBeforeAdd + 1),
                $"Radios count after adding new != {radiosCountBeforeAdd + 1}" );
        }

        [Test]
        public async Task Test_DeleteRadio()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            int radiosCountBeforeDelete = context.Radios.Count();
            await radioService.DeleteEntityAsync(targetRadioId);
            Assert.IsTrue(context.Radios.All(x => x.Id != $"{userId}-{radioFormViewModel.Url}"),
                "There is no entity in database with this Id!");
            Assert.That(context.Radios.Count(), Is.EqualTo(radiosCountBeforeDelete - 1),
                $"Radios count after delete != {radiosCountBeforeDelete - 1}");
        }

        [Test]
        public async Task Test_FindTargetAsync()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            var radio = radioService.FindTargetAsync(targetRadioId);
            Assert.That(radio, !Is.Null, "Target radio is not finded!");
        }

        [Test]
        public async Task Test_GetGroupsAsync()
        {
            int groupsCount = context.Groups.Count();
            ICollection<GroupViewModel> groups = new List<GroupViewModel>();
            groups = await radioService.GetGroupsAsync();
            Assert.That(groups.Count, Is.EqualTo(groupsCount),
                $"Group count != {groupsCount}");
        }

        [Test]
        public async Task Test_EditIsFavoriteAsync()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            await radioService.EditIsFavoriteAsync(radioPlayerViewModel, userId);
            var radio = await context.Radios.FindAsync(radioPlayerViewModel.Id);
            Assert.That(radio.IsFavorite, Is.True,
                "IsFavorite is not changed!");
        }

        [Test]
        public async Task Test_EditRadioAsync()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            radioFormViewModel.Id = targetRadioId;
            radioFormViewModel.Url = "http://radio.edit";
            await radioService.EditRadioAsync(radioFormViewModel, userId);
            var radio = await context.Radios.FindAsync(radioFormViewModel.Id);
            Assert.That(radio.Url, Is.EqualTo("http://radio.edit"), 
                "Edit is not done!");
        }

        [Test]
        public async Task Test_GetStreamTitle()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            string title = await radioService.GetStreamTitle(radioFormViewModel.Url);
            Assert.That(title, !Is.Empty, 
                $"Stream title method is not working");
        }

        [Test]
        public async Task Test_AllGroupsNamesAsync()
        {
            int groupsCount = context.Groups.Count();
            ICollection<string> groupNames = new List<string>();
            groupNames = await radioService.AllGroupsNamesAsync();
            Assert.That(groupNames.Count, Is.EqualTo(groupsCount),
                $"Names count != {groupsCount}");
        }

        [TearDown]
        public void Teardown()
        {
            radioFormViewModel = null!;
            radioPlayerViewModel = null!;
            context.Dispose();
        }
    }
}
