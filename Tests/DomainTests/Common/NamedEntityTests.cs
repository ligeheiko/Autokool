using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class NamedEntityTests : AbstractTests<UniqueEntity<TestData>>
    {
        private TestData data;
        private class testClass : NamedEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            return new testClass(data);
        }
        [TestMethod]
        public void NameTest() => isProperty(data.Name);
    }
}
