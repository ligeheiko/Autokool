using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;

namespace Autokool.Tests
{
    public abstract class AbstractTests<TBaseClass> : BaseClassTests<TBaseClass>

    {
        [TestMethod] public void IsAbstract() => Assert.IsTrue(type.IsAbstract);
        protected override Type getBaseClass() => obj.GetType().BaseType.BaseType;
    }
}
