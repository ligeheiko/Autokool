using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RoleTypeDataTests : SealedTests<object>
    {
        [TestMethod]
        public void AdministratorIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void StudentIDTest()
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
