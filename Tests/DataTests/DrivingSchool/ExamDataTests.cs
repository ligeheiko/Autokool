using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamDataTests : SealedTests<DateData>
    {
        [TestMethod]
        public void PassedTest()
        {
            isProperty<bool>(false);
        }
        [TestMethod]
        public void ExamTypeIDTest()
        {
            isProperty<string>();
        }
    }
}
