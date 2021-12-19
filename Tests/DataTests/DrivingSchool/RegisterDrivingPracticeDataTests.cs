using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RegisterDrivingPracticeDataTests : SealedTests<RegisterData>
    {
        [TestMethod]
        public void DrivingPracticeIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void TeacherIDTest()
        {
            isProperty<string>();
        }
    }
}
