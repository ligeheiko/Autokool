using Autokool.Data.DrivingSchool;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class SchoolDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void AdministratorIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void TeacherIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void StudentIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void CourseIDTest()
        {
            isProperty<string>();
        }
    }
}
