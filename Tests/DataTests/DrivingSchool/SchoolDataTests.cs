using Autokool.Data.DrivingSchool;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class SchoolDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void AdministratorTest()
        {
            isProperty<AdministratorData>();
        }
        [TestMethod]
        public void TeacherTest()
        {
            isProperty<TeacherData>();
        }
        [TestMethod]
        public void StudentTest()
        {
            isProperty<StudentData>();
        }
        [TestMethod]
        public void CourseTest()
        {
            isProperty<CourseData>();
        }
    }
}
