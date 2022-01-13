using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Autokool.Tests.InfraTests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class UserRolesAdminPageTests : AuthorizedPageTests<UserRolesAdminPage,ViewPage<UserRolesAdminPage,
        IUserRolesRepo, UserRoles, UserRolesView, UserRolesData>>
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private int count;
        [TestInitialize]
        public override void TestInitialize()
        {
            
            initInMemoryDatabase();
            count = random(1,5);
            var userStore = new UserStore<ApplicationUser>(appDb);
            var roleStore = new RoleStore<IdentityRole>(appDb);
            userManager = MockHelpers.TestUserManager(userStore);
            roleManager = MockHelpers.TestRoleManager(roleStore);
            ContextSeed.SeedRolesAsync(userManager, roleManager).ConfigureAwait(true);
            base.TestInitialize();
            for (int i = 0; i < count; i++)
            {
               userManager.CreateAsync(random<ApplicationUser>()).ConfigureAwait(true);
            }
        }
        protected override object createObject()
        {
            return new UserRolesAdminPage(userManager, roleManager, MockRepos.UserRolesRepos());
        }
        protected override string expectedUrl => "/Administrator/UserRoles";
        protected override List<string> expectedIndexTableColumns
            => new() {  };
        [TestMethod]
        public async Task OnGetIndexAsyncTest()
        {
            areNotEqual(count, page.usersDataList.Count);
            areNotEqual(page.SelectedId, id);
            await page.OnGetIndexAsync(sortOrder, id, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
            areEqual(count, page.usersDataList.Count);
            areEqual(page.SelectedId, id);
        }
        [TestMethod]
        public async Task OnGetManageAsyncTest()
        {
            areEqual(0, page.userRolesList.Count);
            var user = random<ApplicationUser>();
            await userManager.CreateAsync(user);
            await page.OnGetManageAsync(user.Id);
            areEqual(4, page.userRolesList.Count);
        }
        [TestMethod]
        public async Task OnPostManageAsyncTest()
        {
            List<bool> selected = new List<bool> { true, true, true };
            var user = random<ApplicationUser>();
            await userManager.CreateAsync(user);
            isFalse(await userManager.IsInRoleAsync(user, "Administrator"));
            isFalse(await userManager.IsInRoleAsync(user, "Teacher"));
            await page.OnPostManageAsync(user.Id, selected);
            isTrue(await userManager.IsInRoleAsync(user, "Administrator"));
            selected.Remove(true);
            await page.OnPostManageAsync(user.Id, selected);
            isTrue(await userManager.IsInRoleAsync(user, "Teacher"));
        }
        [TestMethod]
        public void usersDataListTest()
        {
            isProperty(page.usersDataList);
        }
        [TestMethod]
        public void userRolesListTest()
        {
            isProperty(page.userRolesList);
        }
    }
}
