using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class DrivingPracticeStudentPageTests : AuthorizedPageTests<DrivingPracticeBasePage<DrivingPracticeStudentPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new DrivingPracticeStudentPage(user, MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos(), MockRepos.RegisterDrivingPracticeRepos());
        }
    }
}
