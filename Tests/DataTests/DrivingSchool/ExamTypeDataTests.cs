using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamTypeDataTests : BaseTests<ExamTypeData, object>
    {
        [TestMethod]
        public void IDTest()
        {
            TestProperty<string>(nameof(obj.ID));
        }
        [TestMethod]
        public void TheoryExamTest()
        {
            TestProperty<string>(nameof(obj.TheoryExam));
        }
        [TestMethod]
        public void DrivingExamTest()
        {
            TestProperty<string>(nameof(obj.DrivingExam));
        }
    }
}
