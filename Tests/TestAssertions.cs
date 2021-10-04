using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests
{
    public class TestAssertions
    {
        protected static void notTested(string message = null) => Assert.Inconclusive(message);
        protected static void notTested(string message, params object[] parameters)
            => Assert.Inconclusive(message, parameters);
        protected static void areEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreEqual(e, a);
        protected static void areNotEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreNotEqual(e, a);
        protected static void isNull<TExpected>(TExpected e) => Assert.IsNull(e);
        protected static void isNotNull<TExpected>(TExpected e) => Assert.IsNotNull(e);
        protected static void isTrue(bool e) => Assert.IsTrue(e);
        protected static void isFalse(bool e) => Assert.IsFalse(e);
    }
}
