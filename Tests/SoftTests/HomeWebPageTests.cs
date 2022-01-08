using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests
{
    [TestClass]
    public class HomeWebPageTests : BaseWebPageTests
    {
        [TestMethod]
        public async Task IndexPageRequestTest()
        {
            string html = await getHtml("/Index");
            isTrue(html.Contains("<h1 class=\"display-4\">Welcome</h1>"));
        }
    }
}
