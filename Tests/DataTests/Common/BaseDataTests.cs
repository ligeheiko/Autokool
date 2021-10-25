using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        protected override object createObject()
        {
            return new testClass();
        }
    }
}
