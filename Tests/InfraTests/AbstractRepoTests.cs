using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests
{
    [TestClass]
    public abstract class AbstractRepoTests<TRepo, TDomain, TData> :
        RepoTests<TRepo, TDomain, TData>
        where TRepo : UniqueEntitiesRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>
        where TData : BaseData, new()
    {
        [TestMethod] public override void IsSealed() => isFalse(type?.IsSealed ?? true);
        [TestMethod] public void IsAbstract() => isTrue(type?.IsAbstract ?? false);
    }
}
