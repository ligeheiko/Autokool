using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Facade.Common;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class RegisterViewTests : AbstractTests<BaseView>
    {
        private class testClass : RegisterView { }
        protected override object createObject() => new testClass();
        [TestMethod] public void UserNameTest() => isDisplayProperty<string>("UserName");
        [TestMethod] public void UserIdTest() => isDisplayProperty<string>("UserId");
        [TestMethod] public void IsRegisteredTest() => isDisplayProperty<bool>("IsRegistered", false);
    }
}
