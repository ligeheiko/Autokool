using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class ExamTypesAdminPageTests : AuthorizedPageTests<ExamTypesBasePage<ExamTypesAdminPage>>
    {
        protected override object createObject()
        {
            return new ExamTypesAdminPage(MockRepos.ExamTypeRepos());
        }
    }
}
