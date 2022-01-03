using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class ExamsStudentPageTests : AuthorizedPageTests<ExamsStudentPage,ExamsBasePage<ExamsStudentPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new ExamsStudentPage(user, MockRepos.ExamRepos(), MockRepos.ExamTypeRepos(), MockRepos.RegisterExamRepos());
        }
        protected override string expectedUrl => "/Student/Exams";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "ExamTypeID", "ValidFrom", "ValidTo" };
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "ExamTypeID")
            {
                areEqual("Unspecified", actual);
            }
            else
            {
                base.validateValue(actual, expected);
            }
        }
    }
}
