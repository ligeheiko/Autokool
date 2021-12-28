using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class BaseRepoTests : AbstractRepoTests<CourseRepo, Course, CourseData>
    {
        protected override object createObject()
        {
            return new CourseRepo(new InMemoryApplicationDbContext().AppDb);
        }
        protected override Course toObject(CourseData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            areEqual(typeof(object), b);
        }
        [TestMethod]
        public void SqlQueryTest()
        {
            var b = repo.createSqlQuery().Expression.ToString();
            isTrue(b.Contains(".Select"));
        }
    }
}