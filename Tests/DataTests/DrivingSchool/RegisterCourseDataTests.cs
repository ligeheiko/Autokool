using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RegisterCourseDataTests : SealedTests<RegisterData>
    {
        [TestMethod]
        public void CourseIDTest()
        {
            isProperty<string>();
        }
    }
}