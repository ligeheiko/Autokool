using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class ExamTypeTests : SealedTests<NamedEntity<ExamTypeData>>
    {
        private ExamTypeData data;
        protected override object createObject()
        {
            return new ExamType(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ExamTypeData>();
            base.TestInitialize();
        }
    }
}
