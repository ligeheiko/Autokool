using Autokool.Pages.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.Pages.Common.Consts
{
    [TestClass]
    public class DropDownHtmlTests : BaseTests {
        [TestInitialize]
        public void TestInitialize()
            => type = typeof(DropDownHtml);

        //public static IHtmlContent DropDown<TModel, TResult>(
        //    this IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e,
        //    IEnumerable<SelectListItem> items) {

        //    var s = htmlStrings(h, e, items);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings<TModel, TResult>(
        //    IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e,
        //    IEnumerable<SelectListItem> items) {

        //    return new List<object> {
        //        new HtmlString("<dt class=\"col-sm-2\">"),
        //        h.LabelFor(e, new {@class = "text-dark"}),
        //        new HtmlString("</dt>"),
        //        new HtmlString("<dd class=\"col-sm-10\">"),
        //        h.DropDownListFor(e, items, new {@class = "form-control"}),
        //        h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
        //        new HtmlString("</dd>")
        //    };
        //}
    }
}
