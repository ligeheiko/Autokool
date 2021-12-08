using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class ManageUserRolesTests : SealedTests<NamedEntity<ManageUserRolesData>>
    {
        private ManageUserRolesData data;
        protected override object createObject()
        {
            return new ManageUserRoles(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ManageUserRolesData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void RoleIdTest() => isProperty(data.RoleId);
        [TestMethod]
        public void RoleNameTest() => isProperty(data.RoleName);
        [TestMethod]
        public void SelectedTest() => isProperty(data.Selected);
    }
}
