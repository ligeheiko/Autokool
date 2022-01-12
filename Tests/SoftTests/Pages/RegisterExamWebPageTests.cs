using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class RegisterExamWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
            => new() { "/Administrator/RegisterExam/Index?handler=index" };

        protected override string expectedHtml => "<h1>Users registered for Exam</h1>";
    }
}