using Autokool.Pages.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.Pages.Common.Consts
{

    [TestClass]
    public class EditorHtmlTests : BaseTests {
        [TestInitialize]
        public void TestInitialize()
            => type = typeof(EditorHtml);


        //public static IHtmlContent Editor<TModel, TResult>(
        //    this IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e) {

        //    var s = htmlStrings(h, e);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings<TModel, TResult>(
        //    IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e) {

        //    return new List<object> {
        //        new HtmlString("<dt class=\"col-sm-2\">"),
        //        h.LabelFor(e),
        //        new HtmlString("</dt>"),
        //        new HtmlString("<dd class=\"col-sm-10\">"),
        //        h.EditorFor(e, new {htmlAttributes = new {@class = "form-control"}}),
        //        h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
        //        new HtmlString("</dd>")
        //    };
        //}

        //public static IHtmlContent Editor<TModel, TResult>(
        //    this IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e, string displayName) {

        //    var s = htmlStrings(h, e, displayName);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings<TModel, TResult>(
        //    IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e, string displayName) {

        //    return new List<object> {
        //        new HtmlString("<dt class=\"col-sm-2\">"),
        //        h.Label(displayName),
        //        new HtmlString("</dt>"),
        //        new HtmlString("<dd class=\"col-sm-10\">"),
        //        h.EditorFor(e, new {htmlAttributes = new {@class = "form-control"}}),
        //        h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
        //        new HtmlString("</dd>")
        //    };
        //}

    }

}
