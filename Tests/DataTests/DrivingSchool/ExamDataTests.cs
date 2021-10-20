using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamDataTests : SealedTests<BaseData>
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
