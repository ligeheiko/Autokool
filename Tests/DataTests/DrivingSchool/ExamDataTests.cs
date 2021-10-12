﻿using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ExamDataTests : SealedTests<ExamData, BaseData>
    {
        [TestMethod]
        public void PassedTest()
        {
            isProperty<bool>();
        }
        [TestMethod]
        public void ExamTypeIDTest()
        {
            isProperty<string>();
        }
    }
}
