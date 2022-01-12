using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class UserRolesWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
          => new() { "/Administrator/UserRoles/Index?handler=index" };

        protected override string expectedHtml => "<h2>Manage Roles</h2>";
        public override async Task CreatePageRequestLoggedInTest()
        {
            string html = await getHtml("/Administrator/UserRoles/Manage?userId=1&amp;handler=Manage", true);
            isTrue(html.Contains("Manage User Roles"));
        }
    }
}