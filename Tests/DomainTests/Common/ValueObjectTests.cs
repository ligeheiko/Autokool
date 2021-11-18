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
        {
            data = GetRandom.ObjectOf<TestData>();
            return new testClass(data);
        }
    }
}
