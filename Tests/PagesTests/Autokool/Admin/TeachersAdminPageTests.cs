using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Autokool.Tests.InfraTests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class TeachersAdminPageTests :
       AuthorizedPageTests<TeachersAdminPage,TeachersBasePage<TeachersAdminPage>>
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext appDb;
        [TestInitialize]
        public override void TestInitialize()
        {
            initInMemoryDatabase();
            var userStore = new UserStore<ApplicationUser>(appDb);
            var roleStore = new RoleStore<IdentityRole>(appDb);
            roleManager = MockHelpers.TestRoleManager(roleStore);
            _userManager = MockHelpers.TestUserManager(userStore);
            ContextSeed.SeedRolesAsync(_userManager, roleManager).ConfigureAwait(true);
            base.TestInitialize();
            page.teacher = random<Teacher>();
            page.Item = random<TeacherView>();
            appDb.AddAsync(page.Item);
        }
        protected override object createObject()
        {
            return new TeachersAdminPage(MockRepos.TeacherRepos(), _userManager);
        }
        protected override string expectedUrl => "/Administrator/Teachers";
        protected override List<string> expectedIndexTableColumns
            => new() { "FullName","Email","PhoneNr", "ValidFrom", "ValidTo" };
        [TestMethod]
        public async Task OnPostCreateAsyncTest()
        {
            isNull(page.user);
            await page.OnPostCreateAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            isNotNull(page.user);
            isTrue(await _userManager.IsInRoleAsync(page.user, "Teacher"));
        }
        private void initInMemoryDatabase()
        {
            var im = new InMemoryApplicationDbContext();
            appDb = im.AppDb;
        }
    }
}