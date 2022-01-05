using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using System.Security.Principal;
using HttpContextMoq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Data.DrivingSchool;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class CoursesStudentPageTests : AuthorizedPageTests<CoursesStudentPage,CoursesBasePage<CoursesStudentPage>>
    {
        private UserManager<ApplicationUser> userManager;
        public ClaimsPrincipal claims;
        private IRegisterCourseRepo registerCourses;
        protected override string expectedUrl => "/Student/Courses";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "CourseTypeID", "Location", "ValidFrom", "ValidTo" };
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var httpContextMock = new HttpContextMock();
            var testUserManager = MockHelpers.MockUserManager<ApplicationUser>();
        }

        protected override object createObject()
        {
            registerCourses = addItems<RegisterCourse, RegisterCourseData>(MockRepos.RegisterCourseRepos(),
                d => new RegisterCourse(d)) as IRegisterCourseRepo;
            userManager = MockUser();
            var httpContextMock = new HttpContextMock();
            claims = httpContextMock.User;
            return new CoursesStudentPage(userManager, MockRepos.CourseRepos(), MockRepos.CourseTypeRepos(), registerCourses);
        }
        [TestMethod]
        public async Task CourseTypesTest() =>
            await selectListTest(page._registerCourse, registerCourses);
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "CourseTypeID")
            {
                areEqual("Unspecified", actual);
            }
            else
            {
                base.validateValue(actual, expected);
            }
        }
        [TestMethod]
        public async Task OnGetIndexAsyncTest()
        {
            isNull(page.Item);
            notTested(); //TODO mocki httpcontext et saada praegu kasutaja
            var result = await page.OnGetIndexAsync(
                                id, sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue) as PageResult;
            isNotNull(page.Item);
            
        }
        public UserManager<ApplicationUser> MockUser()
        {
            var testUser = MockHelpers.TestUserManager<ApplicationUser>();
            return testUser;
        }
    }
}
