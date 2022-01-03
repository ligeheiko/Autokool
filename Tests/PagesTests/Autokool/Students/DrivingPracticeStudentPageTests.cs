using Autokool.Data.Common;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Autokool.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Students
{
    [TestClass]
    public class DrivingPracticeStudentPageTests : AuthorizedPageTests<DrivingPracticeStudentPage,DrivingPracticeBasePage<DrivingPracticeStudentPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new DrivingPracticeStudentPage(user, MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos(), MockRepos.RegisterDrivingPracticeRepos());
        }
        protected override string expectedUrl => "/Student/DrivingPractices";
        protected override List<string> expectedIndexTableColumns
            => new() { "TeacherID", "ValidFrom", "ValidTo" };
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "TeacherID")
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
