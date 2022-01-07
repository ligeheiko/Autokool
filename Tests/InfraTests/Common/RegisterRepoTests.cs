using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.Common
{
    [TestClass]
    public class RegisterRepoTests : AbstractRepoTests<RegisterCourseRepo, RegisterCourse, RegisterCourseData>
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
        protected override object createObject()
           => new RegisterCourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterCourse toObject(RegisterCourseData data) => new RegisterCourse(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            var b = getBaseClass();
            isTrue(b.Name.StartsWith(nameof(UniqueEntitiesRepo<RegisterCourse, RegisterCourseData>)));
        }
        [TestMethod]
        public async Task RegisterDataToUserTest()
        {
            areNotEqual(_user.Id, _registerCourse.ID);
            areNotEqual(_user.Id, _registerCourse.UserId);
            areNotEqual(_user.UserName, _registerCourse.UserName);
            await repo.RegisterDataToUser(_data, _user, repo, _registerCourse.ID);
            areEqual(_user.Id, _registerCourse.ID);
            areEqual(_user.Id, _registerCourse.UserId);
            areEqual(_user.UserName, _registerCourse.UserName);
        }
    }
}
