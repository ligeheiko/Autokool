using System;
using System.Linq;
using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace Autokool.Infra.Common
{

    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IUniqueEntity<TData>
        where TData : BaseData, new()
    {

        public int PageIndex { get; set; }
        public int TotalPages => getTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public int PageSize { get; set; } = DefaultPageSize;

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        internal int getTotalPages(in int pageSize)
        {
            var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);

            return pages;
        }

        internal int countTotalPages(int count, in int pageSize) => (int)Math.Ceiling(count / (double)pageSize);

        internal int getItemsCount() => base.createSqlQuery().CountAsync().Result;

        protected internal override IQueryable<TData> createSqlQuery() => addSkipAndTake(base.createSqlQuery());

        private IQueryable<TData> addSkipAndTake(IQueryable<TData> query)
        {
            if (PageIndex < 1) return query;

            return query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize);
        }

    }

}