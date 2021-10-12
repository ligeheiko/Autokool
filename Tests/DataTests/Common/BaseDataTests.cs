using Autokool.Aids;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class BaseDataTests : AbstractTests<BaseData, object>
    {
        [TestMethod]
        public void IDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void ValidToTest()
        {
            isProperty<DateTime>();
        }
        [TestMethod]
        public void ValidFromTest()
        {
            isProperty<DateTime>();
        }
    }
}
