using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Autokool.Infra.Common
{
    public abstract class RegisterRepo<TDomain, TData, TRepo> : UniqueEntitiesRepo<TDomain, TData>
        where TDomain : IUniqueEntity<TData>
        where TData : RegisterData, new()
        where TRepo : IRepo<TDomain>
    {
        protected RegisterRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
        public virtual async Task RegisterDataToUser(TData rData, ApplicationUser currentUser, TRepo r, string id)
        {
            rData.ID = currentUser.Id;
            rData.UserId = currentUser.Id;
            rData.UserName = currentUser.UserName;
            rData.IsRegistered = true;
            var obj = toDomainObject(rData);
            await r.Add(obj).ConfigureAwait(true);
        }
    }
}
