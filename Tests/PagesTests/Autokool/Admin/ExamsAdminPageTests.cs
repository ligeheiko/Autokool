using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class ExamsAdminPageTests : AuthorizedPageTests<ExamsAdminPage,ExamsBasePage<ExamsAdminPage>>
    {
        protected override object createObject()
        {
            return new ExamsAdminPage(MockRepos.ExamRepos(), MockRepos.ExamTypeRepos());
        }
        protected override string expectedUrl => "/Administrator/Exams";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name","ExamTypeID", "ValidFrom", "ValidTo" };
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
