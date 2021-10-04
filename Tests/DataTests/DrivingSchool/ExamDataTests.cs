using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamDataTests : BaseTests<ExamData, BaseData>
    {
        [TestMethod]
        public void PassedTest()
        {
            TestProperty<bool>(nameof(obj.Passed));
        }
        [TestMethod]
        public void ExamTypeTest()
        {
            TestProperty<string>(nameof(obj.ExamTypeID));
        }
    }
}
