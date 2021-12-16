using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class RegisterCourseViewTests : SealedTests<RegisterView>
    {
        [TestMethod]
        public void CourseIDTest() => isDisplayProperty<string>("Course Name");
    }
}