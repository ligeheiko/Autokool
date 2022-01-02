using Autokool.Data.Common;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class TeachersAdminPageTests :
       AuthorizedPageTests<TeachersBasePage<TeachersAdminPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new TeachersAdminPage(MockRepos.TeacherRepos(), user);
        }
    }
}
