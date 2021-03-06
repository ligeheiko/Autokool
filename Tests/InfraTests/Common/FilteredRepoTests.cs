using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class FilteredRepoTests : AbstractRepoTests<CourseRepo,Course, CourseData>
    {
        protected override object createObject()
           => new CourseRepo(new InMemoryApplicationDbContext().AppDb);

        protected override Course toObject(CourseData d) => new(d);
        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            isTrue(b.Name.StartsWith(nameof(SortedRepo<Course, CourseData>)));
        }
        [TestMethod] public void SearchStringTest() => isProperty<string>();
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        [TestMethod] public void FixedFilterTest() => isProperty<string>();
        [TestMethod] public void FixedValueTest() => isProperty<string>();
        [TestMethod]
        public void SqlQueryTest()
        {
            var b = repo.createSqlQuery().Expression.ToString();
            isFalse(b.Contains("Where"));
            repo.SearchString = random<string>();
            b = repo.createSqlQuery().Expression.ToString();
            isTrue(b.Contains(".Where"));
        }
    }
}