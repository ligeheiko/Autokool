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
    public abstract class RepoTests<TRepo, TDomain, TData>
        : SealedTests<UniqueEntitiesRepo<TDomain, TData>>
         where TRepo : UniqueEntitiesRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>
        where TData : BaseData, new()
    {
        protected ApplicationDbContext appDb;
        protected TDomain item;
        protected int count;
        protected TRepo repo;
        protected DbSet<TData> dbSet;
        [TestInitialize]
        public override void TestInitialize()
        {
            initInMemoryDatabase();
            base.TestInitialize();
            initRepoAndDbSet();
            initDatabaseItems();
            isInDb(item);
        }
        [TestCleanup]
        public override void TestCleanup()
        {
            cleanDbSet();
            base.TestCleanup();
        }
        [TestMethod]
        public async Task GetTest()
        {
            var l = await repo.Get();
            areEqual(count, l.Count);
        }
        [TestMethod] public void GetByIdAsyncTest() { }
        [TestMethod]
        public async Task DeleteTest()
        {
            await repo.Delete(item.ID);
            isNotInDb(item.ID);
            areEqual(count - 1, dbSet.Count());
        }
        [TestMethod]
        public async Task AddTest()
        {
            item = getRandomItem();
            isNotInDb(item.ID);
            await repo.Add(item);
            isInDb(item);
            areEqual(count + 1, dbSet.Count());
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            var d1 = random<TData>();
            d1.ID = item.ID;
            item = toObject(d1);
            await repo.Update(item);
            isInDb(item);
            areEqual(count, dbSet.Count());
        }
        [TestMethod]
        public void GetByIdTest()
        {
            var o = repo.GetById(item.ID) as TDomain;
            areEqualProperties(o.Data, item.Data);
            areEqual(count, dbSet.Count());
        }
        private TDomain getRandomItem() => toObject(random<TData>());
        protected abstract TDomain toObject(TData data);

        private void initRepoAndDbSet()
        {
            repo = obj as TRepo;
            dbSet = repo.dbSet;
            areEqual(0, dbSet.Count());
        }
        private void initDatabaseItems()
        {
            count = GetRandom.UInt8(10, 20);
            var idx = GetRandom.UInt8(0, (byte)count);
            for (var i = 0; i < count; i++)
            {
                var o = getRandomItem();
                repo.Add(o).GetAwaiter();
                if (i != idx) continue;
                item = o;
            }
            areEqual(count, dbSet.Count());
        }
        private void initInMemoryDatabase()
        {
            var im = new InMemoryApplicationDbContext();
            appDb = im.AppDb;
        }
        private void cleanDbSet()
        {
            foreach (var p in dbSet) appDb.Entry(p).State = EntityState.Deleted;
            appDb.SaveChanges();
        }
        private void isNotInDb(string id)
        {
            var actual = dbSet.Find(id);
            isNull(actual);
        }
        private void isInDb(TDomain i)
        {
            var actual = dbSet.Find(i.ID);
            areEqualProperties(i.Data, actual);
        }
    }
}
