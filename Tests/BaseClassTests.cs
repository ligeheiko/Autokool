using Autokool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public abstract class BaseClassTests<TClass, TBaseClass>: BaseTests where TClass : class
    {
        protected TClass obj
        {
            get => objUnderTests as TClass;
            set => objUnderTests = value;
        }
        protected abstract TClass createObject();
        protected virtual Type getBaseClass() => typeof(TBaseClass);
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(TClass);
            obj = createObject();
        }
        [TestMethod]
        public void CanCreateTest()
        {
            isNotNull(createObject());
        }
        [TestMethod]
        public void IsInheritedFrom()
        {
            areEqual(getBaseClass(), type.BaseType);
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
