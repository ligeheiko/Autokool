using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class SortedRepoTests : AbstractRepoTests<CourseRepo, Course, CourseData>
    {
        protected override object createObject()
            => new CourseRepo(new InMemoryApplicationDbContext().AppDb);

        protected override Course toObject(CourseData d) => new(d);

        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            isTrue(b.Name.StartsWith(nameof(BaseRepo<Course, CourseData>)));
        }

        [TestMethod] public void SortOrderTest() => isProperty<string>();
        [TestMethod] public void DescendingStringTest() => isProperty("_desc");
    }
}