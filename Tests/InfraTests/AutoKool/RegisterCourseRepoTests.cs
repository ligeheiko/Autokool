using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterCourseRepoTests :
        RepoTests<RegisterCourseRepo, RegisterCourse, RegisterCourseData>
    {
        private RegisterCourseData _data;
        private RegisterCourse _registerCourse;
        private ApplicationUser _user;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _user = random<ApplicationUser>();
            _data = random<RegisterCourseData>();
            _registerCourse = toObject(_data);
        }
        protected override object createObject() => new RegisterCourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterCourse toObject(RegisterCourseData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterCourse, RegisterCourseData, IRegisterCourseRepo>), getBaseClass());
        }
        [TestMethod]
        public async Task RegisterDataToUserTest()
        {
            areNotEqual(_user.Id, _registerCourse.ID);
            areNotEqual(_user.Id, _registerCourse.UserId);
            areNotEqual(_user.UserName, _registerCourse.UserName);
            areNotEqual("11", _registerCourse.CourseID);
            await repo.RegisterDataToUser(_data, _user, repo, "11");
            areEqual("11", _registerCourse.CourseID);
            areEqual(_user.Id, _registerCourse.ID);
            areEqual(_user.Id, _registerCourse.UserId);
            areEqual(_user.UserName, _registerCourse.UserName);
        }
    }
}