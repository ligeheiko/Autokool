using Autokool.Pages.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.Pages.Common.Consts
{

    [TestClass]
    public class BackToHtmlTests : BaseTests {
        [TestInitialize]
        public void TestInitialize()
            => type = typeof(BackToHtml);

        //public static IHtmlContent BackTo(
        //    this IHtmlHelper h, Args a) {
        //    if (h == null) throw new ArgumentNullException(nameof(h));

        //    var s = htmlStrings(a ?? new Args());

        //    return new HtmlContentBuilder(s);
        //}

        //internal static List<object> htmlStrings(Args a) {
        //    a.PageUrl = new Uri($"./{getPageUrl(a.PageUrl)}", UriKind.Relative);
        //    a.Handler = getHandler(a.Handler);
        //    a.Action = null;
        //    a.ItemId = null;
        //    a.Title = getTitle(a.Title);
        //    a.ControlId = "backToList";
        //    var s = Href.Compose(a);
        //    return new List<object> {
        //        new HtmlString(s)
        //    };
        //}

        //internal static string getTitle(string s) => s ?? Captions.BackToList;

        //internal static string getHandler(string s) => s ?? Actions.Index;

        //internal static Uri getPageUrl(Uri s) => s ?? new Uri(Actions.Index, UriKind.Relative);

    }

}
