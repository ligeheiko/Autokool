using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    public class RoleTypeTests : SealedTests<NamedEntity<RoleTypeData>>
    {
        private RoleTypeData data;
        protected override object createObject()
        {
            return new RoleType(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<RoleTypeData>();
            base.TestInitialize();
        }
    }
}
