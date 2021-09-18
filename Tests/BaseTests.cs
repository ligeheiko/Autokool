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
        protected void TestProperty<TType>(Action<TType>set , Func<TType> get)
        {
            //Genereeri random var
            //omista see set abil propertile
            //get meetodiga leiad vaartuse
            // assert, genereeritud ja tegelik on vordsed
            //ma ei suutnud valja moelda seda
            Assert.Inconclusive();
        }
    }
}
