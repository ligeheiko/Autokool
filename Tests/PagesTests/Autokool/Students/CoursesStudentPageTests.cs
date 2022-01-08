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
using System;
using Autokool.Aids;
using Autokool.Infra;
using NSubstitute;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class CoursesStudentPageTests : AuthorizedPageTests<CoursesStudentPage,CoursesBasePage<CoursesStudentPage>>
    {
        private UserManager<ApplicationUser> userManager;
        public ClaimsPrincipal claims;
        private HttpContextMock httpContextMock;
        public HttpContext HttpContext => page.HttpContext;
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

           

            userManager = MockUser();
            //httpContextMock = random<HttpContextMock>();

            //httpContextMock.User = user;
            //httpContextMock.User = MockHttpContext(ApplicationUser)
            //claims = httpContextMock.User;
            return new CoursesStudentPage(userManager, MockRepos.CourseRepos(), MockRepos.CourseTypeRepos(), MockRepos.RegisterCourseRepos());
        }
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
            notTested(); //TODO httpcontexti mockides ei saa result mingit tulemust
            isNull(page.Item);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                 new Claim(ClaimTypes.Name, "Test"),

             }, "mock"));
            //var user = Substitute.For<ClaimsPrincipal>();
            
            page.PageContext.HttpContext = new DefaultHttpContext();
            page.PageContext.HttpContext.User = user;
            page.PageContext.HttpContext.Request.Headers["device-id"] = "20317";
            await page.GetCurrentUserAsync(page.PageContext.HttpContext);
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
