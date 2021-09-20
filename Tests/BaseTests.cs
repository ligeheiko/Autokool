using Contoso.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class BaseTests<TObject, TBaseObject> where TObject : new ()
    {
        protected TObject obj { get; private set; }
        [TestInitialize]
        public void TestInitialize()
        {
            obj = new TObject();
        }
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(obj);
        }
        [TestMethod]
        public void IsInheritedFrom()
        {
            Assert.IsInstanceOfType(obj, typeof(TBaseObject));
        }
        protected void TestProperty<TType>(string propertyName)
        {
            var properyInfo = obj.GetType().GetProperty(propertyName);
            Assert.IsNotNull(properyInfo);
            var expected = GetRandom.ValueOf<TType>();
            properyInfo.SetValue(obj, expected);
            var actual = properyInfo.GetValue(obj);
            Assert.AreEqual(expected, actual);
        }
    }
}
