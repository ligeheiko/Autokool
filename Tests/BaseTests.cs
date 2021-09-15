using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
