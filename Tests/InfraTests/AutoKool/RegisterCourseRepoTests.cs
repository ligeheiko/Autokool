using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterCourseRepoTests :
        SealedRepoTests<RegisterCourseRepo, RegisterCourse, RegisterCourseData>
    {
        protected override object createObject() => new RegisterCourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterCourse toObject(RegisterCourseData data) => new(data);
    }
}