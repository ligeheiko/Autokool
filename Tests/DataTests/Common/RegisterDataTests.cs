using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class RegisterDataTests : AbstractTests<BaseData>
    {
        private class testClass : RegisterData { }
        protected override object createObject()
        {
            return new testClass();
        }
        [TestMethod]
        public void UserIdTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void UserNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void IsRegisteredTest()
        {
            isProperty<bool>(false);
        }
    }
}
