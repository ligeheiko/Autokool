using Autokool.Data.Common;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class TeachersAdminPageTests :
       AuthorizedPageTests<TeachersBasePage<TeachersAdminPage>>
    {
        private UserManager<ApplicationUser> user;
        private TeachersAdminPage page;
        protected override object createObject()
        {
            return page = new TeachersAdminPage(MockRepos.TeacherRepos(), user);
        }
        protected override string expectedUrl => "/Administrator/Teachers";
        protected override List<string> expectedIndexTableColumns
            => new() { "FullName","Email","PhoneNr", "ValidFrom", "ValidTo" };
        [TestMethod]
        public async Task OnPostCreateAsync()
        {
            var result = await page.OnPostCreateAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            notTested();
        }
    }
}
