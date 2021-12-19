using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class BaseRepoTests : AbstractTests<object>
    {
        private class testClass : BaseRepo<Course, CourseData>
        {
            public testClass(DbContext c, DbSet<CourseData> s) : base(c, s) { }

            protected override async Task<CourseData> getData(string id) => await dbSet.FirstOrDefaultAsync(x => x.ID == id);

            protected override CourseData getDataById(CourseData d) => dbSet.Find(d.ID);

            protected internal override Course toDomainObject(CourseData d) => new Course(d);
        }
        private ApplicationDbContext AppDb;
        private Course item;
        private int count;
        private BaseRepo<Course, CourseData> repo;
        private DbSet<CourseData> dbSet;

        [TestInitialize]
        public override void TestInitialize()
        {
            initInMemoryDatabase();
            base.TestInitialize();
            initRepoAndDbSet();
            initDatabaseItems();
            IsInDb(item);
        }
        [TestCleanup]
        public override void TestCleanup()
        {
            CleanDbSet();
            base.TestCleanup();
        }
        protected override object createObject() => new testClass(AppDb, AppDb.Courses);
        [TestMethod]
        public async Task GetTest()
        {
            var l = await repo.Get();
            areEqual(count, l.Count);
        }
        [TestMethod] public void GetByIdAsyncTest() { }
        [TestMethod]
        public void GetByIdTest()
        {
            var o = repo.GetById(item.ID) as Course;
            areEqualProperties(o.Data, item.Data);
            areEqual(count, dbSet.Count());
        }
        [TestMethod]
        public async Task DeleteTest()
        {
            await repo.Delete(item.ID);
            IsNotInDb(item.ID);
            areEqual(count - 1, dbSet.Count());
        }
        [TestMethod]
        public async Task AddTest()
        {
            item = GetRandomItem();
            IsNotInDb(item.ID);
            await repo.Add(item);
            IsInDb(item);
            areEqual(count + 1, dbSet.Count());
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            var d1 = random<CourseData>();
            d1.ID = item.ID;
            item = new Course(d1);
            await repo.Update(item);
            IsInDb(item);
            areEqual(count,dbSet.Count());
        }
        private void CleanDbSet()
        {
            foreach (var p in dbSet)
            {
                AppDb.Entry(p).State = EntityState.Deleted;
            }
            AppDb.SaveChanges();
        }
        private Course GetRandomItem()
        {
           return new Course(random<CourseData>());
        }
        private void initRepoAndDbSet()
        {
            repo = obj as BaseRepo<Course, CourseData>;
            dbSet = repo.dbSet;
            areEqual(0, dbSet.CountAsync().GetAwaiter().GetResult());
        }
        private void initDatabaseItems()
        {
            count = GetRandom.UInt8(10, 20);
            var idx = GetRandom.UInt8(0, (byte)count);
            for (int i = 0; i < count; i++)
            {
                var o = GetRandomItem();
                dbSet.Add(o.Data);
                if (i != idx) continue;
                item = o;
            }
            AppDb.SaveChanges();
            areEqual(count, dbSet.Count());
        }
        private void initInMemoryDatabase()
        {
            var inMemory = new InMemoryApplicationDbContext();
            AppDb = inMemory.AppDb;
        }
        private void IsNotInDb(string id)
        {
            var actual = dbSet.Find(id);
            isNull(actual);
        }
        private void IsInDb(Course i)
        {
            var actual = dbSet.Find(i.ID);
            areEqualProperties(i.Data, actual);
        }
    }
}