using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class CourseRepoTests : 
        SealedTests<UniqueEntitiesRepo<Course, CourseData>>
    {
        protected override object createObject()
        {
            return new CourseRepo(new InMemoryApplicationDbContext().AppDb);
        }
    }
}