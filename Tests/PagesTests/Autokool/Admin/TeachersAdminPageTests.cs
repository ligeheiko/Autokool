using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Autokool.Tests.InfraTests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
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
            page.Item = random<TeacherView>();
            appDb.AddAsync(page.Item).ConfigureAwait(true);
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
        [TestMethod]
        public async Task OnGetEditAsyncTest()
        {
            areNotEqual(page.UserId, id);
            var p = await page.OnGetEditAsync(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            areEqual(page.UserId, id);
        }
        [TestMethod]
        public async Task OnPostEditAsyncTest()
        {
            var oldUser = page.user;
            oldUser = random<ApplicationUser>();
            await _userManager.CreateAsync(oldUser);
            isNotNull(_userManager.GetUserIdAsync(oldUser));
            await page.OnPostEditAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, oldUser.Id);
            var listOfTeachers = await _userManager.GetUsersInRoleAsync(Roles.Teacher.ToString());
            isFalse(listOfTeachers.Contains(oldUser));
            isTrue(listOfTeachers.Contains(page.user));
        }
        [TestMethod]
        public async Task OnPostDeleteAsyncTest()
        {
            page.user = random<ApplicationUser>();
            page.user.Id = page.Item.ID;
            await _userManager.CreateAsync(page.user);
            var count = _userManager.Users.Count();
            areEqual(1, count);
            await page.OnPostDeleteAsync(page.Item.ID, sortOrder, searchString,pageIndex, fixedFilter, fixedValue);
            var expected = await _userManager.FindByIdAsync(page.Item.ID);
            isNull(expected);
            count = _userManager.Users.Count();
            areEqual(0, count);
        }
        [TestMethod]
        public void UserIdTest()
        {
            page.UserId = random<string>();
            isProperty(page.UserId);
        }
        [TestMethod]
        public void userTest()
        {
            page.user = random<ApplicationUser>();
            isProperty(page.user);
        }
        private void initInMemoryDatabase()
        {
            var im = new InMemoryApplicationDbContext();
            appDb = im.AppDb;
        }
    }
}