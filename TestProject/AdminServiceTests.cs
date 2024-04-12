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
    public class AdminServiceTests
    {
        private IAdminService adminService;
        private ILogger<AdminService> loggerAdmin;
        private IRadioService radioService;
        private ILogger<RadioService> loggerUser;
        private StreamorDbContext context;
        private string userId;
        private string targetRadioId;
        private RadioFormViewModel radioFormViewModel;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<StreamorDbContext>()
                .UseInMemoryDatabase("RadioDB")
                .Options;
            context = new StreamorDbContext(contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var loggerMockAdmin = new Mock<ILogger<AdminService>>();
            loggerAdmin = loggerMockAdmin.Object;
            adminService = new AdminService(context, loggerAdmin);

            var loggerMockUser = new Mock<ILogger<RadioService>>();
            loggerUser = loggerMockUser.Object;
            radioService = new RadioService(context, loggerUser);

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
        }

        [Test]
        public async Task Test_AdminDeleteRadio()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            int radiosCountBeforeDelete = context.Radios.Count();
            await adminService.DeleteEntityAsync(targetRadioId);
            Assert.IsTrue(context.Radios.All(x => x.Id != $"{userId}-{radioFormViewModel.Url}"),
                "There is no entity in database with this Id!");
            Assert.That(context.Radios.Count(), Is.EqualTo(radiosCountBeforeDelete - 1),
                $"Radios count after delete != {radiosCountBeforeDelete - 1}");
        }

        [Test]
        public async Task Test_AdminFindTargetAsync()
        {
            await radioService.AddNewRadioAsync(radioFormViewModel, userId);
            var radio = adminService.FindTargetAsync(targetRadioId);
            Assert.That(radio, !Is.Null, "Target radio is not finded!");
        }

        [Test]
        public async Task Test_AllUsernames()
        {
            int usersCount = context.Users.Count();
            ICollection<string> users = new List<string>();
            users = await adminService.AllUsernamesAsync();
            Assert.That(users.Count, Is.EqualTo(usersCount - 1),
                $"Users count without admin is not {usersCount - 1}");
        }

        [TearDown]
        public void Teardown()
        {
            radioFormViewModel = null!;
            context.Dispose();
        }
    }
}
