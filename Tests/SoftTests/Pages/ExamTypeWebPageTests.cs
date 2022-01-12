using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class ExamTypeWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
            => new() { "/Administrator/ExamTypes/Index?handler=index" };

        protected override string expectedHtml => "<h1>Exam Types</h1>";
        protected override string pageName => "ExamTypes";
    }
}