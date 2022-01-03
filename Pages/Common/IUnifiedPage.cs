using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Autokool.Pages.Common
{
    public interface IUnifiedPage<TPage> where TPage : PageModel
    {
        public string GetName(IHtmlHelper<TPage> html, int i);
        public IHtmlContent GetValue(IHtmlHelper<TPage> html, int i);
    }
}