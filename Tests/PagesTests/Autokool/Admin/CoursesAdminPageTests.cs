using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class CoursesAdminPageTests : AuthorizedPageTests<CoursesBasePage<CoursesAdminPage>>
    {
        protected override object createObject()
        {
            return new CoursesAdminPage(MockRepos.CourseRepos(), MockRepos.CourseTypeRepos());
        }
    }
}
