using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class NamedEntityDataTests : AbstractTests<BaseData>
    {
        private class testClass : NamedEntityData { }
        protected override object createObject()
        {
            return new testClass();
        }
        [TestMethod]
        public void NameTest()
        {
            isProperty<string>();
        }
    }
}
