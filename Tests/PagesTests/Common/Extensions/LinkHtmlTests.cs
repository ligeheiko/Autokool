using Autokool.Pages.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.Pages.Common.Consts
{

    [TestClass]
    public class LinkHtmlTests : BaseTests {
        [TestInitialize]
        public void TestInitialize()
            => type = typeof(LinkHtml);


        //public static IHtmlContent Link(
        //    this IHtmlHelper htmlHelper, string text, params Link[] items) {
        //    var s = htmlStrings(text, items);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings(string text, Link[] items) {
        //    var l = new List<object> {
        //        new HtmlString("<p>"),
        //        new HtmlString($"<a>{text}</a>")
        //    };

        //    l.AddRange(
        //        items.Select(item => new HtmlString($"<a> </a><a href=\"{item.Url}\">{item.DisplayName}</a>")));

        //    l.Add(new HtmlString("</p>"));

        //    return l;
        //}

        //public static IHtmlContent Link(
        //    this IHtmlHelper htmlHelper, params Link[] items) {
        //    var s = htmlStrings(items);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings(Link[] items) {
        //    var l = new List<object>();

        //    l.AddRange(
        //        items.Select(item => new HtmlString($"<a href=\"{item.Url}\">{item.DisplayName}</a>")));

        //    return l;
        //}

    }

}
