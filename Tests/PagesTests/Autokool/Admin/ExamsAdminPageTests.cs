using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class ExamsAdminPageTests : AuthorizedPageTests<ExamsBasePage<ExamsAdminPage>>
    {
        protected override object createObject()
        {
            return new ExamsAdminPage(MockRepos.ExamRepos(), MockRepos.ExamTypeRepos());
        }
    }
}
