using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class CourseTypesAdminPageTests : SealedTests<CourseTypesBasePage<CourseTypesAdminPage>>
    {
        protected override object createObject()
        {
            return new CourseTypesAdminPage(MockRepos.CourseTypeRepos());
        }
    }
}
