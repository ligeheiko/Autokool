using Autokool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public abstract class BaseClassTests<TBaseClass>: BaseTests
    {
        protected object obj
        {
            get => objUnderTests;
            set => objUnderTests = value;
        }
        protected abstract object createObject();
        protected virtual Type getBaseClass() => typeof(TBaseClass);
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = getTestableClassType();
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
        //protected void TestProperty<TType>(string propertyName)
        //{
        //    var properyInfo = obj.GetType().GetProperty(propertyName);
        //    Assert.IsNotNull(properyInfo);
        //    var expected = GetRandom.ValueOf<TType>();
        //    properyInfo.SetValue(obj, expected);
        //    var actual = properyInfo.GetValue(obj);
        //    Assert.AreEqual(expected, actual);
        //}
        // Vana test
    }
}
