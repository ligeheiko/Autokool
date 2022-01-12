using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class TeachersWebPage : BaseWebPageTests
    {
        protected override List<string> expectedUrl
           => new() { "/Administrator/Teachers/Index?handler=index", "/Student/Teachers/Index?handler=index" };

        protected override string expectedHtml => "<h1>Teachers</h1>";
        protected override string pageName => "Teachers";
    }
}