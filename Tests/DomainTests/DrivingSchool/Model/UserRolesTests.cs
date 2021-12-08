using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class UserRolesTests : SealedTests<UniqueEntity<UserRolesData>>
    {
        private UserRolesData data;
        protected override object createObject()
        {
            return new UserRoles(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<UserRolesData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void UserIdTest() => isProperty(data.UserId);
        [TestMethod]
        public void UserNameTest() => isProperty(data.UserName);
        [TestMethod]
        public void FirstNameTest() => isProperty(data.FirstName);
        [TestMethod]
        public void LastNameTest() => isProperty(data.LastName);
        [TestMethod]
        public void EmailTest() => isProperty(data.Email);
        [TestMethod]
        public void RolesTest() => isProperty(data.Roles);
    }
}
