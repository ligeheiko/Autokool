using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autokool.Aids;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class UniqueEntityTests : AbstractTests<ValueObject<TestData>>
    {
        private TestData data;
        private class testClass : UniqueEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            return new testClass(data);
        }
        [TestMethod]
        public void IDTest() => isProperty(data.ID);
    }
}
