﻿using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;
using Autokool.Data.Common;

namespace Autokool.Tests.DomainTests.Common
{
    public class TestData : PersonData { }
    [TestClass]
    public class PersonEntityTests : AbstractTests<DateEntity<TestData>>
    {
        private TestData data;
        private class testClass : PersonEntity<TestData>
        {
            public testClass(TestData d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestData>();
            return new testClass(data);
        }
        [TestMethod]
        public void FirstNameTest() => isProperty(data.FirstName);
        [TestMethod]
        public void LastNameTest() => isProperty(data.LastName);
        [TestMethod]
        public void PhoneNrTest() => isProperty(data.PhoneNr);
        [TestMethod]
        public void EmailTest() => isProperty(data.Email);
    }
}
