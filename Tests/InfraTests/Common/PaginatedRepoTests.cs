using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class PaginatedRepoTests : AbstractRepoTests<CourseRepo,Course, CourseData>
    {
        protected override object createObject()
           => new CourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override Course toObject(CourseData d) => new(d);
        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            isTrue(b.Name.StartsWith(nameof(FilteredRepo<Course, CourseData>)));
        }
        [TestMethod] public void PageIndexTest() => isProperty<int>(false);
        [TestMethod] public void TotalPagesTest() => isProperty(repo.getTotalPages(repo.PageSize));
        [TestMethod] public void HasNextPageTest() => isBooleanProperty(repo.PageIndex < repo.TotalPages);
        [TestMethod] public void HasPreviousPageTest() => isBooleanProperty(repo.PageIndex > 1);
        [TestMethod] public void PageSizeTest() => isProperty<int>(false);
        [TestMethod]
        public void SqlQueryTest()
        {
            var b = repo.createSqlQuery().Expression.ToString();
            isFalse(b.Contains(".Skip"));
            isFalse(b.Contains(".Take"));
            repo.PageIndex = 1;
            b = repo.createSqlQuery().Expression.ToString();
            isTrue(b.Contains(".Skip"));
            isTrue(b.Contains(".Take"));
        }
    }
}