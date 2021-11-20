using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;
using System;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class BaseEntityTests : AbstractTests<object>
    {
        private class testClass : BaseEntity { }
        protected override object createObject() => new testClass();
        [TestMethod] public void UnspecifiedTest() => isProperty(Aids.Constants.Word.Unspecified);
        [TestMethod] public void UnspecifiedValidFromTest() => isProperty(DateTime.MinValue);
        [TestMethod] public void UnspecifiedValidToTest() => isProperty(DateTime.MaxValue);
        [TestMethod] public void UnspecifiedDoubleTest() => isProperty(double.NaN);
        [TestMethod] public void UnspecifiedDecimalTest() => isProperty(decimal.MaxValue);
        [TestMethod] public void UnspecifiedIntegerTest() => isProperty(0);
        [TestMethod]
        public void IsUnspecifiedTest()
        {
            Assert.IsTrue(BaseEntity.isUnspecified(null));
            Assert.IsTrue(BaseEntity.isUnspecified(string.Empty));
            Assert.IsTrue(BaseEntity.isUnspecified(Aids.Constants.Word.Unspecified));
            Assert.IsFalse(BaseEntity.isUnspecified(GetRandom.String()));
        }
    }
}
