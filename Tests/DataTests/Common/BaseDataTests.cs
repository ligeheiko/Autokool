using Autokool.Aids;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class BaseDataTests : AbstractTests<object>
    {
        private class testClass : BaseData { }
        [TestMethod]
        public void IDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void ValidToTest()
        {
            isProperty<DateTime>(false);
        }
        [TestMethod]
        public void ValidFromTest()
        {
            isProperty<DateTime>(false);
        }

        protected override object createObject()
        {
            return new testClass();
        }
    }
}
