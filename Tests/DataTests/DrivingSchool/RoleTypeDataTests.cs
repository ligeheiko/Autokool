using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RoleTypeDataTests : BaseTests<RoleTypeData, object>
    {
        [TestMethod]
        public void AdministratorIDTest()
        {
            TestProperty<string>(nameof(obj.AdministratorID));
        }
        [TestMethod]
        public void StudentIDTest()
        {
            TestProperty<string>(nameof(obj.StudentID));
        }
        [TestMethod]
        public void TeacherIDTest()
        {
            TestProperty<string>(nameof(obj.TeacherID));
        }
    }
}
