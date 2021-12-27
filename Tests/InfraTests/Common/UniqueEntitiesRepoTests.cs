using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class UniqueEntitiesRepoTests : AbstractRepoTests<CourseRepo, Course, CourseData>
    {
        protected override object createObject()
            => new CourseRepo(new InMemoryApplicationDbContext().AppDb);

        protected override Course toObject(CourseData d) => new(d);

        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            isTrue(b.Name.StartsWith(nameof(PaginatedRepo<Course, CourseData>)));
        }
    }
}
