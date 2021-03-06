using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
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
