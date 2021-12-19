using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class RegisterDrivingPracticeViewTests : SealedTests<RegisterView>
    {
        [TestMethod]
        public void TeacherIDTest() => isDisplayProperty<string>("Teacher's Name");
        [TestMethod]
        public void DrivingPracticeIDTest() => isDisplayProperty<string>("DrivingPracticeID");
    }
}