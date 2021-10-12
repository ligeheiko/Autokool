using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class StudentDataTests : SealedTests<StudentData, PersonData>
    {
        [TestMethod]
        public void CourseTest()
        {
            isProperty<CourseData>();
        }
    }
}
