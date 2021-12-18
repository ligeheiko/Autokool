using System;
using System.Collections.Generic;
using System.Linq;
using Autokool.Aids.Constants;
using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Autokool.Pages.Common
{

    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : BaseView
    {

        protected internal TitledPage(TRepository r, string title) : base(r) => PageTitle = title;

        public string PageTitle { get; }

        public string PageSubTitle => FixedValue is null
        ? string.Empty
        : $"{pageSubtitle()}";

        protected internal virtual string pageSubtitle() => string.Empty;

        public Uri PageUrl => pageUrl();
        public Uri CreateUrl => createUrl();

        protected internal Uri createUrl()
            => new Uri($"{PageUrl}/Create" +
                       "?handler=Create" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        protected abstract Uri pageUrl();

        public Uri IndexUrl => indexUrl();

        protected internal Uri indexUrl() =>
            new Uri($"{PageUrl}/Index?handler=Index&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);

        protected internal static IEnumerable<SelectListItem> newItemsList<TTDomain, TTData>(
            IRepo<TTDomain> r,
            Func<TTDomain, bool> condition = null,
            Func<TTData, string> getName = null)
            where TTDomain : IUniqueEntity<TTData>
            where TTData : NamedEntityData, new()
        {
            Func<TTData, string> name = d => (getName is null) ? (d as INamedEntityData)?.Name : getName(d);
            var items = r?.Get().GetAwaiter().GetResult();
            var l = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                    .Select(m => new SelectListItem(name(m.Data), m.Data.ID))
                    .ToList() :
                    items
                    .Where(condition)
                    .Select(m => new SelectListItem(name(m.Data), m.Data.ID))
                    .ToList();
            l.Insert(0, new SelectListItem(Word.Unspecified, null));
            return l;
            
        }
        protected internal static IEnumerable<SelectListItem> newItemsListTeacherID<TTDomain, TTData>(
            IRepo<TTDomain> r,
            Func<TTDomain, bool> condition = null,
            Func<TTData, string> getName = null)
            where TTDomain : IUniqueEntity<TTData>
            where TTData : NamedEntityData, new()
        {
            Func<TTData, string> name = d => (getName is null) ? (d as DrivingPracticeData)?.TeacherID : getName(d);
            var items = r?.Get().GetAwaiter().GetResult();
            var l = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                    .Select(m => new SelectListItem(name(m.Data), m.Data.ID))
                    .ToList() :
                    items
                    .Where(condition)
                    .Select(m => new SelectListItem(name(m.Data), m.Data.ID))
                    .ToList();
            l.Insert(0, new SelectListItem(Word.Unspecified, null));
            return l;

        }

        protected internal static string itemName(IEnumerable<SelectListItem> list, string id)
        {
            if (list is null) return Word.Unspecified;

            foreach (var m in list)
                if (m.Value == id)
                    return m.Text;

            return Word.Unspecified;
        }

        public virtual bool IsMasterDetail() => PageSubTitle != string.Empty;
    }
}
