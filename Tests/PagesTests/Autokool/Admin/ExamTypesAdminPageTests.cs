using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class ExamTypesAdminPageTests : AuthorizedPageTests<ExamTypesAdminPage,ExamTypesBasePage<ExamTypesAdminPage>>
    {
        protected override object createObject()
        {
            return new ExamTypesAdminPage(MockRepos.ExamTypeRepos());
        }
        protected override string expectedUrl => "/Administrator/ExamTypes";
        protected override List<string> expectedIndexTableColumns
            => new() { "ID", "Name" };
    }
}
