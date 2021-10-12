using Autokool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests
{
    public abstract class AbstractTests<TClass, TBaseClass> :
        BaseClassTests<TClass, TBaseClass> where TClass : class

    {
        [TestMethod] public void IsAbstract() => Assert.IsTrue(type.IsAbstract);

        protected override TClass createObject()
        {
            return GetRandom.ObjectOf<TClass>();
        }
    }
}
