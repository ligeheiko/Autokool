using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private CourseData d;
        private Course o;
        private int count;

        [TestInitialize]
        public override void TestInitialize()
        {
            var inMemory = new InMemoryApplicationDbContext();
            AppDb = inMemory.AppDb;
            base.TestInitialize();
            var dbSet = (obj as testClass).dbSet;
            areEqual(0, dbSet.CountAsync().GetAwaiter().GetResult());

            d = random<CourseData>();
            o = new Course(d);
            count = GetRandom.Int8(10, 20);
            for (int i = 0; i < count; i++)
            {
                (obj as ICrudMethods<Course>).Add(new Course(random<CourseData>())).GetAwaiter();
            }
            areEqual(count, dbSet.CountAsync().GetAwaiter().GetResult());
        }
        [TestCleanup]
        public override void TestCleanup()
        {
            var dbSet = (obj as testClass).dbSet;
            foreach (var p in dbSet)
            {
                AppDb.Entry(p).State = EntityState.Deleted;
            }
            AppDb.SaveChanges();
            base.TestCleanup();

        }
        protected override object createObject() => new testClass(AppDb, AppDb.Courses);
        [TestMethod]
        public async Task GetTest()
        {
            var l = await (obj as ICrudMethods<Course>).Get();
            areEqual(count, l.Count);
        }
        [TestMethod] public void GetByIdAsyncTest() { }
        [TestMethod]
        public async Task GetByIdTest()
        {
            var actual = await(obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(new CourseData(), actual.Data, nameof(d.ID));
            var count = await(obj as testClass).dbSet.CountAsync();
            await(obj as ICrudMethods<Course>).Add(o);
            actual = (obj as testClass).GetById(d.ID) as Course;
            areEqualProperties(d, actual.Data);
            areEqual(count + 1, await(obj as testClass).dbSet.CountAsync());
        }
        [TestMethod]
        public async Task DeleteTest()
        {
            await (obj as ICrudMethods<Course>).Add(o);
            var actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(d, actual.Data);
            var count = await (obj as testClass).dbSet.CountAsync();
            await (obj as ICrudMethods<Course>).Delete(o.ID);
            actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(new CourseData(), actual.Data, nameof(d.ID));
            areEqual(count - 1, await (obj as testClass).dbSet.CountAsync());
        }
        [TestMethod]
        public async Task AddTest()
        {
            var actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(new CourseData(), actual.Data, nameof(d.ID));
            var count = await (obj as testClass).dbSet.CountAsync();
            await (obj as ICrudMethods<Course>).Add(o);
            actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(d, actual.Data);
            areEqual(count + 1, await (obj as testClass).dbSet.CountAsync());
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            await (obj as ICrudMethods<Course>).Add(o);
            var actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(d, actual.Data);
            var count = await (obj as testClass).dbSet.CountAsync();
            var d1 = random<CourseData>();
            d1.ID = d.ID;
            await (obj as ICrudMethods<Course>).Update(new Course(d1));
            actual = await (obj as ICrudMethods<Course>).Get(d.ID);
            areEqualProperties(d1, actual.Data);
            areEqual(count, await (obj as testClass).dbSet.CountAsync());
        }
    }
}