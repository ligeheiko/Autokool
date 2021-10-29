﻿using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RoleTypeDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void AdministratorIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void StudentIDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void TeacherIDTest()
        {
            isProperty<string>();
        }
    }
}
