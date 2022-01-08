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
    public class RegisterExamRepoTests :
        RepoTests<RegisterExamRepo, RegisterExam, RegisterExamData>
    {
        private ApplicationUser _user;
        private RegisterExamData _data;
        private RegisterExam _registerExam;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _user = random<ApplicationUser>();
            _data = random<RegisterExamData>();
            _registerExam = toObject(_data);
        }
        protected override object createObject() => new RegisterExamRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterExam toObject(RegisterExamData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterExam, RegisterExamData, IRegisterExamRepo>), getBaseClass());
        }
        [TestMethod]
        public async Task RegisterDataToUserTest()
        {
            areNotEqual(_user.Id, _registerExam.ID);
            areNotEqual(_user.Id, _registerExam.UserId);
            areNotEqual(_user.UserName, _registerExam.UserName);
            areNotEqual("11", _registerExam.ExamID);
            await repo.RegisterDataToUser(_data, _user, repo, "11");
            areEqual("11", _registerExam.ExamID);
            areEqual(_user.Id, _registerExam.ID);
            areEqual(_user.Id, _registerExam.UserId);
            areEqual(_user.UserName, _registerExam.UserName);
        }
    }
}