using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterCourseRepoTests :
        SealedTests<UniqueEntitiesRepo<RegisterCourse, RegisterCourseData>>
    {
        protected override object createObject()
        {
            return new RegisterCourseRepo(new InMemoryApplicationDbContext().AppDb);
        }
    }
}
