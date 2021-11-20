using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Tests.DomainTests.Common
{
    public class TestData : PersonData { }
    [TestClass]
    public class PersonEntityTests : AbstractTests<DateEntity<TestData>>
    {
        private TestData data;
        public RoleTypeData roleTypeData;

        private class MockRoleTypeRepo : RepoMock<RoleType>, IRoleTypeRepo { }
        private class testClass : PersonEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            createMockRoleTypeRepo();
            return new testClass(data);
        }
        protected void createMockRoleTypeRepo()
        {
            var count = GetRandom.UInt8(10, 20);
            var index = GetRandom.UInt8(0, count);
            var repo = new MockRoleTypeRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<RoleTypeData>();
                if (index == i)
                {
                    d.ID = data.RoleTypeID;
                    roleTypeData = d;
                }
                repo.Add(new RoleType(roleTypeData)).GetAwaiter();
            }
            GetRepo.SetServiceProvider(new ServiceProviderMock(repo));
        }
        [TestMethod]
        public void FirstNameTest() => isProperty(data.FirstName);
        [TestMethod]
        public void LastNameTest() => isProperty(data.LastName);
        [TestMethod]
        public void PhoneNrTest() => isProperty(data.PhoneNr);
        [TestMethod]
        public void EmailTest() => isProperty(data.Email);
        [TestMethod]
        public void RoleTypeIDTest() => isProperty(data.RoleTypeID);
        [TestMethod]
        public void FullNameTest()
        {
            var r = Safe.Run(() => data.LastName + ", " + data.FirstName, BaseEntity.Unspecified);
            isProperty(r);
        }
        [TestMethod]
        public void RoleTypeTest()
        {
            var p = (obj as PersonEntity<TestData>).RoleType;
            isNotNull(p);
            areEqual(roleTypeData.ID, p.ID);
        }
    }
}
