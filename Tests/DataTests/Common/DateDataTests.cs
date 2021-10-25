using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class DateDataTests : AbstractTests<BaseData>
    {
        private class testClass : DateData { }
        protected override object createObject()
        {
            return new testClass();
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
    }
}
