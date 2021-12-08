using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class BaseViewTests : AbstractTests<object>
    {
        private class testClass : BaseView { }
        protected override object createObject() => new testClass();
        [TestMethod]
        public void IDTest() => isRequiredProperty<string>("Id");
        [TestMethod]
        public void GetIDTest()
        {
            var o = obj as BaseView;
            areEqual(o.ID, o.GetID());
        }
        [TestMethod]
        public void HasDefaultIdTest()
        {
            var o = obj as BaseView;
            var s = Guid.TryParse(o.ID, out _);
            isTrue(s);
        }
    }
}