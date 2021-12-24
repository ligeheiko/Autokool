using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class ExamRepoTests :
        SealedRepoTests<ExamRepo, Exam, ExamData>
    {
        protected override object createObject() => new ExamRepo(new InMemoryApplicationDbContext().AppDb);
        protected override Exam toObject(ExamData data) => new(data);
    }
}