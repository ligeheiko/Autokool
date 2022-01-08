using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests
{
    [TestClass]
    public class CourseWebPageTests : BaseWebPageTests
    {
        [DataRow("/Administrator/Courses/Index?handler=index")]
        [DataRow("/Student/Courses/Index?handler=index")]
        [DataTestMethod]
        public async Task IndexPageRequestLoggedOutTest(string url)
        {
            string html = await getHtml(url);
            isTrue(html.Contains("<h1>Log in</h1>"));
        }

        [DataRow("/Administrator/Courses/Index?handler=index")]
        [DataRow("/Student/Courses/Index?handler=index")]
        [DataTestMethod]
        public async Task IndexPageRequestLoggedInTest(string url)
        {
            string html = await getHtml(url, true);
            isTrue(html.Contains("<h1>Courses</h1>"));
        }
    }
}
