using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamTypeDataTests : SealedTests<object>
    {
        [TestMethod]
        public void IDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void TheoryExamTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void DrivingExamTest()
        {
            isProperty<string>();
        }
    }
}
