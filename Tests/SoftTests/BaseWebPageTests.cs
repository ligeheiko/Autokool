using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soft;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        protected abstract List<string> expectedUrl { get; }
        protected virtual string expectedHtml => string.Empty;
        protected virtual string pageName => string.Empty;

        [TestMethod]
        public async Task IndexPageRequestLoggedInTest()
        {
            for (int i = 0; i < expectedUrl.Count; i++)
            {
                string html = await getHtml(expectedUrl[i], true);
                isTrue(html.Contains(expectedHtml));
            }
        }
        [TestMethod]
        public virtual async Task IndexPageRequestLoggedOutTest()
        {
            for (int i = 0; i < expectedUrl.Count; i++)
            {
                string html = await getHtml(expectedUrl[i]);
                isTrue(html.Contains("<h1>Log in</h1>"));
            }
        }
        [TestMethod]
        public virtual async Task CreatePageRequestLoggedInTest()
        {
            if (pageName != string.Empty)
            {
                string html = await getHtml($"/Administrator/{pageName}/Create?handler=Create&pageIndex=1&sortOrder=&searchString=&fixedFilter=&fixedValue=", true);
                isTrue(html.Contains("id=\"createButton\""));
            }
            else
            {
                string html = await getHtml(expectedUrl[0], true);
                isFalse(html.Contains("id=\"createButton\""));
            }
        }
        [TestMethod]
        public virtual async Task EditPageRequestLoggedInTest()
        {
            if (pageName != string.Empty)
            {
                string html = await getHtml($"/Administrator/{pageName}/Edit?handler=Edit&id=1&pageIndex=1", true);
                isTrue(html.Contains("id=\"saveButton\""));
            }
            else
            {
                string html = await getHtml(expectedUrl[0], true);
                isFalse(html.Contains("id=\"saveButton\""));
            }
        }
        [TestMethod]
        public virtual async Task DeletePageRequestLoggedInTest()
        {
            if (pageName != string.Empty)
            {
                string html = await getHtml($"/Administrator/{pageName}/Delete?handler=Delete&id=1&pageIndex=1", true);
                isTrue(html.Contains("id=\"deleteButton\""));
            }
            else
            {
                string html = await getHtml(expectedUrl[0], true);
                isFalse(html.Contains("id=\"deleteButton\""));
            }
        }
        [TestMethod]
        public virtual async Task DetailsPageRequestLoggedInTest()
        {
            if (pageName != string.Empty)
            {
                string html = await getHtml($"/Administrator/{pageName}/Details?handler=Details&id=1&pageIndex=1", true);
                isTrue(html.Contains("<h4>Details</h4>"));
            }
            else
            {
                string html = await getHtml(expectedUrl[0], true);
                isFalse(html.Contains("<h4>Details</h4>"));
            }
        }
        protected async Task<string> getHtml(string url, bool isLogged = false)
        {
            var user = isLogged ? loggedUser() : notLoggedUser();
            var page = await user.GetAsync(url);
            areEqual(HttpStatusCode.OK, page.StatusCode);
            return await page.Content.ReadAsStringAsync();
        }
    }
}