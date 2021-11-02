using System;
using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;
using Autokool.Facade.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autokool.Pages.Common
{
    public abstract class ViewsPage<TPage, TRepository, TDomain, TView, TData> :
        ViewPage<TPage, TRepository, TDomain, TView, TData>
        where TPage : PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IUniqueEntity<TData>
        where TData : DateData, new()
        where TView : DateView
    {
        protected ViewsPage(TRepository r, string title) : base(r, title) { }

        protected internal Uri createUri(int i)
        {
            var uri = CreateUrl.ToString();
            uri += $"&switchOfCreate={i}";

            return new Uri(uri, UriKind.Relative);
        }
    }
}
