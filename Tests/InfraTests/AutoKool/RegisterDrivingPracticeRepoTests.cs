using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterDrivingPracticeRepoTests :
        RepoTests<RegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeData>
    {
        private ApplicationUser _user;
        private RegisterDrivingPracticeData _data;
        private RegisterDrivingPractice _registerDrivingPractice;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _user = random<ApplicationUser>();
            _data = random<RegisterDrivingPracticeData>();
            _registerDrivingPractice = toObject(_data);
        }
        protected override object createObject() => new RegisterDrivingPracticeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterDrivingPractice toObject(RegisterDrivingPracticeData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterDrivingPractice, RegisterDrivingPracticeData, IRegisterDrivingPracticeRepo>), getBaseClass());
        }
        [TestMethod]
        public async Task RegisterDataToUserTest()
        {
            areNotEqual(_user.Id, _registerDrivingPractice.ID);
            areNotEqual(_user.Id, _registerDrivingPractice.UserId);
            areNotEqual(_user.UserName, _registerDrivingPractice.UserName);
            areNotEqual("11", _registerDrivingPractice.DrivingPracticeID);
            await repo.RegisterDataToUser(_data, _user, repo, "11");
            areEqual("11", _registerDrivingPractice.DrivingPracticeID);
            areEqual(_user.Id, _registerDrivingPractice.ID);
            areEqual(_user.Id, _registerDrivingPractice.UserId);
            areEqual(_user.UserName, _registerDrivingPractice.UserName);
        }
    }
}