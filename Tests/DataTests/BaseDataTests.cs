using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class BaseDataTests : BaseTests<BaseData, object>
    {
        [TestMethod]
        public void IDTest()
        {
            TestProperty<string>(nameof(obj.ID));
        }
        [TestMethod]
        public void ValidToTest()
        {
            TestProperty<DateTime>(nameof(obj.ValidTo));
        }
        [TestMethod]
        public void ValidFromTest()
        {
            TestProperty<DateTime>(nameof(obj.ValidFrom));
        }
    }
}
