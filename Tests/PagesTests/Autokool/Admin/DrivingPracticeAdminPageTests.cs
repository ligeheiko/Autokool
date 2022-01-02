using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class DrivingPracticeAdminPageTests : AuthorizedPageTests<DrivingPracticeBasePage<DrivingPracticeAdminPage>>
    {
        protected override object createObject()
        {
            return new DrivingPracticeAdminPage(MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
        protected override string expectedUrl => "/Administrator/DrivingPractices";
        protected override List<string> expectedIndexTableColumns
            => new() { "TeacherID","ValidFrom", "ValidTo" };
    }
}
