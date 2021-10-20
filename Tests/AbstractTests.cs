using Autokool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests
{
    public abstract class AbstractTests<TBaseClass> :
        BaseClassTests<TBaseClass>

    {
        [TestMethod] public void IsAbstract() => Assert.IsTrue(type.IsAbstract);
    }
}
