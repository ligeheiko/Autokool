﻿using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void LocationTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void CourseTypeIDTest()
        {
            isProperty<string>();
        }
    }
}
