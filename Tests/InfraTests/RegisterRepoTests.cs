using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Infra;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests
{
    public abstract class RegisterRepoTests<TRepo, TDomain, TData> : RepoTests<TRepo, TDomain, TData>
        where TRepo : UniqueEntitiesRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>
        where TData : BaseData, new()
    {
    }
}
