using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class CourseTypeRepoTests :
        SealedRepoTests<CourseTypeRepo, CourseType, CourseTypeData>
    {
        protected override object createObject() => new CourseTypeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override CourseType toObject(CourseTypeData data) => new(data);
    }
}