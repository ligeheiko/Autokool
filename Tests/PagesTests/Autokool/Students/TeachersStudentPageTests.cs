using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class TeachersStudentPageTests : SealedTests<TeachersBasePage<TeachersStudentPage>>
    {
        protected override object createObject()
        {
            return new TeachersStudentPage(MockRepos.TeacherRepos());
        }
    }
}
