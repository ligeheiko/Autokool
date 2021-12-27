using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class ExamTypeRepoTests :
        RepoTests<ExamTypeRepo, ExamType, ExamTypeData>
    {
        protected override object createObject() => new ExamTypeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override ExamType toObject(ExamTypeData data) => new(data);
    }
}