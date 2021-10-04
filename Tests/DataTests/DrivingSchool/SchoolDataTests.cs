using Autokool.Data.DrivingSchool;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class SchoolDataTests : BaseTests<SchoolData, BaseData>
    {
        [TestMethod]
        public void AdministratorTest()
        {
            TestProperty<AdministratorData>(nameof(obj.Administrator));
        }
        [TestMethod]
        public void TeacherTest()
        {
            TestProperty<TeacherData>(nameof(obj.Teacher));
        }
        [TestMethod]
        public void StudentTest()
        {
            TestProperty<StudentData>(nameof(obj.Student));
        }
        [TestMethod]
        public void CourseTest()
        {
            TestProperty<CourseData>(nameof(obj.Course));
        }
    }
}
