using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterExamRepoTests :
        RepoTests<RegisterExamRepo, RegisterExam, RegisterExamData>
    {
        protected override object createObject() => new RegisterExamRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterExam toObject(RegisterExamData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterExam, RegisterExamData, IRegisterExamRepo>), getBaseClass());
        }
    }
}