using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class FilteredRepoTests : AbstractTests<SortedRepo<Course, CourseData>>
    {
        private class testClass : FilteredRepo<Course, CourseData>
        {
            public testClass(DbContext c, DbSet<CourseData> s) : base(c, s) { }

            protected override async Task<CourseData> getData(string id) => await dbSet.FirstOrDefaultAsync(x => x.ID == id);

            protected override CourseData getDataById(CourseData d) => dbSet.Find(d.ID);

            protected internal override Course toDomainObject(CourseData d) => new Course(d);
        }
        private ApplicationDbContext AppDb;
        [TestInitialize]
        public override void TestInitialize()
        {
            var inMemory = new InMemoryApplicationDbContext();
            AppDb = inMemory.AppDb;
            base.TestInitialize();
        }
        protected override object createObject() => new testClass(AppDb, AppDb.Courses);
    }
}