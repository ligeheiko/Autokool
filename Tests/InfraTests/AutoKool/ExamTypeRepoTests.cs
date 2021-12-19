using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class ExamTypeRepoTests :
        SealedTests<UniqueEntitiesRepo<ExamType, ExamTypeData>>
    {
        protected override object createObject()
        {
            return new ExamTypeRepo(new InMemoryApplicationDbContext().AppDb);
        }
    }
}
