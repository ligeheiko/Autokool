﻿using System.Threading.Tasks;
using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autokool.Pages.Common
{

    public abstract class ViewPage<TPage, TRepository, TDomain, TView, TData> :
        UnifiedPage<TPage, TRepository, TDomain, TView, TData>
        where TPage : PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IUniqueEntity<TData>
        where TData : BaseData, new()
        where TView : BaseView
    {

        protected ViewPage(TRepository r, string title) : base(r, title) { }

        public virtual async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
        }

        public virtual IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex ?? 0;

            return Page();
        }

        public virtual async Task<IActionResult> OnPostCreateAsync(
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            if (!await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
                .ConfigureAwait(true)) return Page();

            return Redirect(IndexUrl.ToString());
        }


        public virtual async Task<IActionResult> OnGetDeleteAsync(
            string id,
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public virtual async Task<IActionResult> OnPostDeleteAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await deleteObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Redirect(IndexUrl.ToString());
        }

        public virtual async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public virtual async Task<IActionResult> OnGetEditAsync(
            string id,
            string sortOrder,
            string searchString,
            int pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public virtual async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await updateObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Redirect(IndexUrl.ToString());
        }


    }

}
