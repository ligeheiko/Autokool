using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class DateEntityTests : AbstractTests<NamedEntity<TestData>>
    {
        private TestData data;
        private class testClass : DateEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            return new testClass(data);
        }
        [TestMethod]
        public void ValidFromTest() => isProperty(data.ValidFrom);
        [TestMethod]
        public void ValidToTest() => isProperty(data.ValidTo);
        
    }
}
