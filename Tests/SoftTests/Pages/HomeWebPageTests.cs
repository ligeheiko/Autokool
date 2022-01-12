using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class HomeWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
            => new() { "/Index" };

        protected override string expectedHtml => "<h1 class=\"display-4\">Welcome</h1>";

        public override async Task IndexPageRequestLoggedOutTest()
        {
            for (int i = 0; i < expectedUrl.Count; i++)
            {
                string html = await getHtml(expectedUrl[i]);
                isTrue(html.Contains("<h1>Welcome</h1>"));
            }
        }
    }
}
