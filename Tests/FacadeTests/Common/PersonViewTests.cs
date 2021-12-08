using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Facade.Common;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class PersonViewTests : AbstractTests<DateView>
    {
        private class testClass : PersonView { }
        protected override object createObject() => new testClass();
        [TestMethod] public void FirstNameTest() => isDisplayProperty<string>("First Name");
        [TestMethod] public void LastNameTest() => isDisplayProperty<string>("Last Name");
        [TestMethod] public void EmailTest() => isRequiredProperty<string>("Email address");
        [TestMethod] public void PhoneNrTest() => isDisplayProperty<string>("Phone number");
        [TestMethod] public void FullNameTest() => isDisplayProperty<string>("Full Name");
    }
}
