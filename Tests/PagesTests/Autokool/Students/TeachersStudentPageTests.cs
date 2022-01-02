using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class TeachersStudentPageTests : AuthorizedPageTests<TeachersBasePage<TeachersStudentPage>>
    {
        private TeachersStudentPage page;
        protected override object createObject()
        {
            return page =  new TeachersStudentPage(MockRepos.TeacherRepos());
        }
        protected override string expectedUrl => "/Student/Teachers";
        protected override List<string> expectedIndexTableColumns
            => new() { "FullName", "Email", "PhoneNr"};
    }
}
