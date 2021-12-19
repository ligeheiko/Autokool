using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class CourseTypeRepoTests :
        SealedTests<UniqueEntitiesRepo<CourseType, CourseTypeData>>
    {
        protected override object createObject()
        {
            return new CourseTypeRepo(new InMemoryApplicationDbContext().AppDb);
        }
    }
}
