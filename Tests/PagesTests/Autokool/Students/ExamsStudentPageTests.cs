using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class ExamsStudentPageTests : AuthorizedPageTests<ExamsBasePage<ExamsStudentPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new ExamsStudentPage(user, MockRepos.ExamRepos(), MockRepos.ExamTypeRepos(), MockRepos.RegisterExamRepos());
        }
    }
}
