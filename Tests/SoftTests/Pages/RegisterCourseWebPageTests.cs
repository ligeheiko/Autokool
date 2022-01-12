using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class RegisterCourseWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl
            => new() { "/Administrator/RegisterCourse/Index?handler=index" };

        protected override string expectedHtml => "<h1>Users registered for Course</h1>";
    }
}
