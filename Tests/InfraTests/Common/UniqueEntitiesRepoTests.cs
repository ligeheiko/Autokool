using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class UniqueEntitiesRepoTests : AbstractTests<PaginatedRepo<Course, CourseData>>
    {
        private class testClass : UniqueEntitiesRepo<Course, CourseData>
        {
            public testClass(DbContext c, DbSet<CourseData> s) : base(c, s) { }

            protected override Course toDomainObject(CourseData d) => new Course(d);
        }
        private ApplicationDbContext AppDb;
        [TestInitialize]
        public override void TestInitialize()
        {
            var inMemory = new InMemoryApplicationDbContext();
            AppDb = inMemory.AppDb;
            base.TestInitialize();
        }
        protected override object createObject()
        {
            return new testClass(AppDb, AppDb.Courses);
        }
    }
}
