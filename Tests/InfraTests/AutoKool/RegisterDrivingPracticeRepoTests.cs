using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterDrivingPracticeRepoTests :
        RepoTests<RegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeData>
    {
        protected override object createObject() => new RegisterDrivingPracticeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterDrivingPractice toObject(RegisterDrivingPracticeData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterDrivingPractice, RegisterDrivingPracticeData, IRegisterDrivingPracticeRepo>), getBaseClass());
        }
    }
}