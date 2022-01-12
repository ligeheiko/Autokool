using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class CourseTypeWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
            => new() { "/Administrator/CourseTypes/Index?handler=index" };

        protected override string expectedHtml => "<h1>Course Types</h1>";
        protected override string pageName => "CourseTypes";
    }
}
