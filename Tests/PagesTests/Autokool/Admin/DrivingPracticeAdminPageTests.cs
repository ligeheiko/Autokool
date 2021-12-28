using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class DrivingPracticeAdminPageTests : SealedTests<DrivingPracticeBasePage<DrivingPracticeAdminPage>>
    {
        protected override object createObject()
        {
            return new DrivingPracticeAdminPage(MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
    }
}
