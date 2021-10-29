using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Autokool.Data.Common;
using Autokool.Domain.Common;

namespace Autokool.Infra.Common
{

    public abstract class UniqueEntitiesRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IUniqueEntity<TData>
        where TData : BaseData, new()
    {

        protected UniqueEntitiesRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> getData(string id)
            => await dbSet.FirstOrDefaultAsync(m => m.ID == id);

        protected override TData getDataById(TData d) => dbSet.Find(d.ID);

    }

}
