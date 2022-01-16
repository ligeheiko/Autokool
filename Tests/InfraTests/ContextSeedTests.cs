using Autokool.Data.Common;
using Autokool.Tests.PagesTests;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Autokool.Infra;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Autokool.Tests.InfraTests
{
    [TestClass]
    public class ContextSeedTests : ClassTests<object>
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext appDb;
        private ApplicationUser _user;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            initInMemoryDatabase();
            var roleStore = new RoleStore<IdentityRole>(appDb);
            var userStore = new UserStore<ApplicationUser>(appDb);
            _userManager = MockHelpers.TestUserManager(userStore);
            roleManager = MockHelpers.TestRoleManager(roleStore);
        }
        [TestCleanup]
        public override void TestCleanup()
        {
            _userManager.Dispose();
            base.TestCleanup();
        }
        [TestMethod]
        public async Task SeedRolesAsyncTest()
        {
            var actual = roleManager.Roles.Count();
            isTrue(actual == 0);
            await ContextSeed.SeedRolesAsync(_userManager, roleManager);
            var expected = 4;
            actual = roleManager.Roles.Count();
            areEqual(expected, actual);
        }
        [TestMethod]
        public async Task SeedSuperAdminAsyncTest()
        {
            isNull(_user);
            await ContextSeed.SeedRolesAsync(_userManager, roleManager);
            _user = await ContextSeed.SeedSuperAdminAsync(_userManager, roleManager, _user);
            isNotNull(_user);
            isTrue(await _userManager.IsInRoleAsync(_user, "SuperAdmin"));
            isTrue(_userManager.Users.Count() == 1);
        }
        private void initInMemoryDatabase()
        {
            var im = new InMemoryApplicationDbContext();
            appDb = im.AppDb;
        }
        [TestMethod]
        public override void CanCreateTest() { }
    }
}