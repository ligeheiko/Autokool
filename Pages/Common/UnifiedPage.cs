using Autokool.Aids;
using Autokool.Aids.Reflection;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.Common;
using Autokool.Pages.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Autokool.Pages.Common
{
    public abstract class UnifiedPage<TPage, TRepository, TDomain, TView, TData>
        : TitledPage<TRepository, TDomain, TView, TData>, IIndexTable<TPage>
        where TPage : PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : BaseView
    {

        protected UnifiedPage(TRepository r, string title) : base(r, title) => createTableColumns();

        protected abstract void createTableColumns();

        public List<LambdaExpression> Columns { get; }
            = new List<LambdaExpression>();

        protected void createColumn<TResult>(Expression<Func<TPage, TResult>> e) => Columns.Add(e);

        public void SetItem(int i)
        {
            Item = null;
            if (isCorrectIndex(i, Items)) Item = Items[i];
        }

        private bool isCorrectIndex<TList>(int i, IList<TList> l) => i >= 0 && i < l?.Count;

        public virtual string GetName(IHtmlHelper<TPage> html, int i) => getName<string>(html, i);
       
        protected string getName<TResult>(IHtmlHelper<TPage> h, int i)
        {
            if (isCorrectIndex(i, Columns))
                return h.DisplayNameFor(Columns[i] as Expression<Func<TPage, TResult>>);
            return Undefined;
        }

        public virtual IHtmlContent GetValue(IHtmlHelper<TPage> html, int i)
            => getValue<string>(html, i);
        protected IHtmlContent getValue<TResult>(IHtmlHelper<TPage> h, int i)
        {
            if (isCorrectIndex(i, Columns))
                return h.DisplayFor(Columns[i] as Expression<Func<TPage, TResult>>);
            return null;
        }
        protected IHtmlContent getRaw<TResult>(IHtmlHelper<TPage> h, TResult r) => h.Raw(r.ToString());

        public virtual Uri GetSortStringExpression(int i)
                    => isCorrectIndex(i, Columns)
                    ? GetSortString(toExpr<string>(Columns[i]), pageUrl())
                    : null;

        public Uri GetSortString<T>(Expression<Func<TPage, T>> e, Uri page)
        {
            var name = GetMember.Name(e);
            var sortOrder = getSortOrder(name);
            var registered = getRegistered();

            return new Uri(
                $"{page}?handler=Index&sortOrder={sortOrder}&currentFilter={CurrentFilter}&searchString={SearchString}"
                + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}&registered={registered}", UriKind.Relative);
        }

        protected Expression<Func<TPage, TResult>> toExpr<TResult>(LambdaExpression e)
            => e as Expression<Func<TPage, TResult>>;


        public int ColumnsCount => Columns?.Count ?? -1;

        public int RowsCount => Items?.Count ?? -1;

        public string Undefined => "Undefined";

    }
}