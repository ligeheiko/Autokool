using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Autokool.Facade.Common;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class DateViewTests : AbstractTests<NamedView>
    {
        private class testClass : DateView { }
        [TestMethod] public void ValidFromTest() => isDateProperty<DateTime?>("Valid From");
        [TestMethod] public void ValidToTest() => isDateProperty<DateTime?>("Valid To");
        protected override object createObject() => new testClass();
    }
}
