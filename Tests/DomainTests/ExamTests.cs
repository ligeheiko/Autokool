using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class ExamTests : SealedTests<BaseEntity<ExamData>>
    {
        private ExamData data;
        protected override object createObject()
        {
            return new Exam(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ExamData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void PassedTest() => isProperty(data.Passed);
        [TestMethod]
        public void ExamTypeIDTest() => isProperty(data.ExamTypeID);
    }
}
