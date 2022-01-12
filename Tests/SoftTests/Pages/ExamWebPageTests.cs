using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class ExamWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
           => new() { "/Administrator/Exams/Index?handler=index", "/Student/Exams/Index?handler=index" };

        protected override string expectedHtml => "<h1>Exams</h1>";
        protected override string pageName => "Exams";
        [TestMethod]
        public override async Task DetailsPageRequestLoggedInTest()
        {
            string html = await getHtml($"/Administrator/{pageName}/Details?handler=Details&id=1&pageIndex=1", true);
            isTrue(html.Contains("<h4>Details</h4>"));
            string htmlStudent = await getHtml($"/Student/{pageName}/Details?handler=Details&id=1&pageIndex=1", true);
            isTrue(htmlStudent.Contains("Confirm Registration"));
        }
        [TestMethod]
        public override async Task EditPageRequestLoggedInTest()
        {
            string html = await getHtml($"/Administrator/{pageName}/Edit?handler=Edit&id=1&pageIndex=1", true);
            isTrue(html.Contains("id=\"saveButton\""));
            string htmlStudent = await getHtml($"/Student/{pageName}/Edit?handler=Edit&id=1&pageIndex=1", true);
            isTrue(htmlStudent.Contains("Confirm Cancellation"));
        }
    }
}