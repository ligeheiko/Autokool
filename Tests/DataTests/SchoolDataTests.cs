using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class SchoolDataTests : BaseTests<SchoolData, BaseData>
    {
        [TestMethod]
        public void AdministratorTest()
        {
            TestProperty<AdministratorData>(nameof(obj.Administrators));
        }
        [TestMethod]
        public void TeacherTest()
        {
            TestProperty<TeacherData>(nameof(obj.Teachers));
        }
        [TestMethod]
        public void StudentTest()
        {
            TestProperty<StudentData>(nameof(obj.Students));
        }
        [TestMethod]
        public void CourseTest()
        {
            TestProperty<CourseData>(nameof(obj.Courses));
        }
    }
}
