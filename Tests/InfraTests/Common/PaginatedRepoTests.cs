using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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
    }
}