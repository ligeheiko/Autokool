using Autokool.Pages.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Autokool.Tests.PagesTests
{
    [TestClass]
    public abstract class AuthorizedPageTests<TPage,TBaseClass> : CommonPageTests<TPage,TBaseClass>
        where TPage : PageModel, IUnifiedPage<TPage>
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
        [TestMethod] public override void IsAbstract() => isFalse(type.IsAbstract);
        [TestMethod] public void IsSealed() => isTrue(type.IsSealed);
        protected override Type getBaseClass() => obj.GetType().BaseType;
    }
}
