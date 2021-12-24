using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class CourseRepoTests :
        SealedRepoTests<CourseRepo, Course, CourseData>
    {
        protected override object createObject() => new CourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override Course toObject(CourseData data) => new(data);
    }
}