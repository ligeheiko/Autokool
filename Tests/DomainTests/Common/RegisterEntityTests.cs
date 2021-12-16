using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Aids;
using Autokool.Data.Common;

namespace Autokool.Tests.DomainTests.Common
{
   
    [TestClass]
    public class RegisterEntityTests : AbstractTests<UniqueEntity<TestDataRegister>>
    {
        private TestDataRegister data;
        private class testClass : RegisterEntity<TestDataRegister>
        {
            public testClass(TestDataRegister d) : base(d) { }
        }
        protected override object createObject()
        {
            data = GetRandom.ObjectOf<TestDataRegister>();
            return new testClass(data);
        }
        [TestMethod]
        public void UserNameTest() => isProperty(data.UserName);
        [TestMethod]
        public void UserIdTest() => isProperty(data.UserId);
        [TestMethod]
        public void IsRegisteredTest() => isProperty(data.IsRegistered);
    }
}
public class TestDataRegister : RegisterData { }
