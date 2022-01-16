using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class CoursesStudentPageTests : AuthorizedPageTests<CoursesStudentPage,CoursesBasePage<CoursesStudentPage>>
    {
        private UserManager<ApplicationUser> userManager;
        public HttpContext HttpContext => page.HttpContext;
        protected override string expectedUrl => "/Student/Courses";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "CourseTypeID", "Location", "ValidFrom", "ValidTo" };
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override object createObject()
        {
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
            var result = await page.OnGetIndexAsync(
                                id, sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue) as PageResult;
            isNotNull(page.Item);
            
        }
    }
}