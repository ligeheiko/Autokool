using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class CourseTypesAdminPageTests : AuthorizedPageTests<CourseTypesBasePage<CourseTypesAdminPage>>
    {
        protected override object createObject()
        {
            return new CourseTypesAdminPage(MockRepos.CourseTypeRepos());
        }
        protected override string expectedUrl => "/Administrator/CourseTypes";
        protected override List<string> expectedIndexTableColumns
            => new() { "ID", "Name"};
    }
}
