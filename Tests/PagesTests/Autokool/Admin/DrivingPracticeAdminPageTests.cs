using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class DrivingPracticeAdminPageTests : AuthorizedPageTests<DrivingPracticeAdminPage,DrivingPracticeBasePage<DrivingPracticeAdminPage>>
    {
        protected override object createObject()
        {
            return new DrivingPracticeAdminPage(MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
        protected override string expectedUrl => "/Administrator/DrivingPractices";
        protected override List<string> expectedIndexTableColumns
            => new() { "TeacherID","ValidFrom", "ValidTo" };
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
