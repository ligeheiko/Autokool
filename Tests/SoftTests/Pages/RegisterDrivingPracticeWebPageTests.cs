using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.SoftTests.Pages
{
    [TestClass]
    public class RegisterDrivingPracticeWebPageTests : BaseWebPageTests
    {
        protected override List<string> expectedUrl 
            => new () {"/Administrator/RegisterDrivingPractice/Index?handler=index"};
        override protected string expectedHtml 
            => "<h1>Users registered for Driving Practice</h1>";
        
    }
}