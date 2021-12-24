using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterExamRepoTests :
        SealedRepoTests<RegisterExamRepo, RegisterExam, RegisterExamData>
    {
        protected override object createObject() => new RegisterExamRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterExam toObject(RegisterExamData data) => new(data);
    }
}