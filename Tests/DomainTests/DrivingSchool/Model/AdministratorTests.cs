using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class AdministratorTests : SealedTests<PersonEntity<AdministratorData>>
    {
        private AdministratorData data;
        protected override object createObject()
        {
            return new Administrator(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<AdministratorData>();
            base.TestInitialize();
        }
    }
}
