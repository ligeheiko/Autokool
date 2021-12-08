using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autokool.Facade.Common;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class NamedViewTests : AbstractTests<BaseView>
    {
        private class testClass : NamedView { }
        protected override object createObject() => new testClass();
        [TestMethod] public void NameTest() => isDisplayProperty<string>("Name");
    }
}