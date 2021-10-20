using Autokool.Data.DrivingSchool;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class PersonRoleDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void PersonIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void RoleTypeIDTest()
        {
            isProperty<string>();
        }
    }
}
