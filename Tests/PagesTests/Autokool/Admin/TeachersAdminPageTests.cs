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
       AuthorizedPageTests<TeachersAdminPage,TeachersBasePage<TeachersAdminPage>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new TeachersAdminPage(MockRepos.TeacherRepos(), user);
        }
        protected override string expectedUrl => "/Administrator/Teachers";
        protected override List<string> expectedIndexTableColumns
            => new() { "FullName","Email","PhoneNr", "ValidFrom", "ValidTo" };
        [TestMethod]
        public async Task OnPostCreateAsync()
        {
            notTested();
            var result = await page.OnPostCreateAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            
        }
    }
}
