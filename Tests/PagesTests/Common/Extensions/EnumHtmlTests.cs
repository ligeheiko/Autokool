using Autokool.Pages.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.Pages.Common.Consts
{

    [TestClass]
    public class EnumHtmlTests : BaseTests {
        [TestInitialize]
        public void TestInitialize()
            => type = typeof(EnumHtml);


        //public static IHtmlContent EnumEditor<TModel, TResult>(
        //    this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {

        //    var l = new SelectList(Enum.GetNames(typeof(TResult)));

        //    var s = htmlStrings(h, e, l);

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h,
        //    Expression<Func<TModel, TResult>> e, SelectList l) {
        //    return new List<object> {
        //        new HtmlString("<dt class=\"col-sm-2\">"),
        //        h.LabelFor(e, new {@class = "text-dark"}),
        //        new HtmlString("</dt>"),
        //        new HtmlString("<dd class=\"col-sm-10\">"),
        //        h.DropDownListFor(e, l, new {@class = "form-control"}),
        //        h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
        //        new HtmlString("</dd>")
        //    };
        //}

    }

}