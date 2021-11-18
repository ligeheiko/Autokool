using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    internal class PersonRoleTests : SealedTests<UniqueEntity<PersonRoleData>>
    {
        private PersonRoleData data;
        protected override object createObject()
        {
            return new PersonRole(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<PersonRoleData>();
            base.TestInitialize();
        }
    }
}
