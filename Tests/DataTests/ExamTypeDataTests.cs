using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
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
