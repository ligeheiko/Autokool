using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class PersonDataTests : AbstractTests<DateData>
    {
        private class testClass : PersonData { }
        [TestMethod]
        public void FirstNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void EmailTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void PhoneNrTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void RoleTypeIDTest()
        {
            isProperty<string>();
        }

        protected override object createObject()
        {
            return new testClass();
        }
    }
}