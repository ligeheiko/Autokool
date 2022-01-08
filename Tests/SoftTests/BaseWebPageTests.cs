using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soft;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests
{
    public abstract class BaseWebPageTests : TestAssertions
    {
        private static readonly TestHost<Startup> hostIsNotLogged;
        private static readonly TestHost<Startup> hostIsLogged;

        static BaseWebPageTests()
        {
            hostIsNotLogged = new TestHost<Startup>();
            hostIsLogged = new TestHost<Startup>(true);
        }
        private static HttpClient notLoggedUser() => hostIsNotLogged.CreateClient();
        private static HttpClient loggedUser() => hostIsLogged.CreateClient();

        protected async Task<string> getHtml(string url, bool isLogged = false)
        {
            var user = isLogged ? loggedUser() : notLoggedUser();
            var page = await user.GetAsync(url);
            areEqual(HttpStatusCode.OK, page.StatusCode);
            return await page.Content.ReadAsStringAsync();
        }
    }
}
