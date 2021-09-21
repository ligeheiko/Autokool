using System.Collections.Generic;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
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
            TestProperty<List<ExamTypeData>>(nameof(obj.ExamTypes));
        }
    }
}
