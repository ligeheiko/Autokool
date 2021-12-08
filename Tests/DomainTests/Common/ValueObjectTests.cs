using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class ValueObjectTests : AbstractTests<BaseEntity>
    {
        private TestData data;
        private class testClass : ValueObject<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
           => new testClass(data);
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TestData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void DataTest()
        {
            Assert.AreSame(data, (obj as testClass).data);
            Assert.AreNotSame(data, (obj as testClass).Data);
            areEqualProperties(data, (obj as testClass).Data);
        }
        [TestMethod]
        public void IsUnspecifiedTest()
        {
            isFalse((obj as testClass).IsUnspecified);
            obj = new testClass(null);
            isTrue((obj as testClass).IsUnspecified);
        }
    }
}
