using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Tests.DomainTests.Common
{
    public class TestData : PersonData { }
    [TestClass]
    public class PersonEntityTests : AbstractTests<DateEntity<TestData>>
    {
        private TestData data;
        private RoleTypeData roleTypeData;
        private IRoleTypeRepo roleTypeRepo;

        private class testClass : PersonEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            roleTypeRepo = MockRepos.RoleTypeRepos(data.RoleTypeID, out roleTypeData);
            return new testClass(data);
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
            var r = Safe.Run(() => data.FirstName + " " + data.Name, BaseEntity.Unspecified);
            isProperty(r);
        }
        [TestMethod]
        public void RoleTypeTest()
        {
            isNull((obj as PersonEntity<TestData>).RoleType);
            GetRepo.SetServiceProvider(new ServiceProviderMock(roleTypeRepo));
            var p = (obj as PersonEntity<TestData>).RoleType;
            isNotNull(p);
            areEqualProperties(roleTypeData, p.Data);
        }
    }
}
