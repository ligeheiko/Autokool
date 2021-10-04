using Autokool.Data.DrivingSchool;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class PersonRoleDataTests : BaseTests<PersonRoleData, BaseData>
    {
        [TestMethod]
        public void PersonIDTest()
        {
            TestProperty<string>(nameof(obj.PersonID));
        }
        [TestMethod]
        public void RoleTypeIDTest()
        {
            TestProperty<string>(nameof(obj.RoleTypeID));
        }
    }
}
