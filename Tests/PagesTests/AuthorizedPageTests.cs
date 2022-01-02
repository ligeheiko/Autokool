using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Autokool.Tests.PagesTests
{
    [TestClass]
    public class AuthorizedPageTests<TBaseClass> : SealedTests<TBaseClass>
    {
        [TestMethod]
        public void IsAuthorizedTest()
        {
            var type = objUnderTests.GetType();
            var list = type?.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            var a = list?.Cast<AuthorizeAttribute>().Single();
            if (a is null)
            {
                isFalse(true, $"Class {type.Name} does not have authorization");
            }
        }
    }
}
