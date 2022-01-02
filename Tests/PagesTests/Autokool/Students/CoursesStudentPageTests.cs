using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Moq;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class CoursesStudentPageTests : AuthorizedPageTests<CoursesBasePage<CoursesStudentPage>>
    {
        private CoursesStudentPage page;
        private UserManager<ApplicationUser> userManager;
        private ApplicationUser user;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            MockUser().ConfigureAwait(true);
            MockUserManager<ApplicationUser>()
        }

        protected override object createObject()
        {
            return page = new CoursesStudentPage(userManager, MockRepos.CourseRepos(), MockRepos.CourseTypeRepos(), MockRepos.RegisterCourseRepos());
        }
        [TestMethod]
        public async Task OnGetIndexAsyncTest()
        {
            string id = random<string>();
            string sortOrder = random<string>();
            string currentFilter = random<string>();
            string searchString = random<string>();
            int? pageIndex = random<int>();
            string fixedFilter = random<string>();
            string fixedValue = random<string>();
            var result = await page.OnGetIndexAsync(
                id, sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
            notTested();

        }
        public async Task<ApplicationUser> MockUser()
        {
            user = await userManager.FindByNameAsync("superadmin");
            return user;
        }
    }
}
