using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests
{
    public abstract class SealedTests<TBaseClass> 
        : ClassTests<TBaseClass>
    {
        [TestMethod]
        public void IsSealed()
        {
            isTrue(type?.IsSealed ?? false);
        }
    }
}
