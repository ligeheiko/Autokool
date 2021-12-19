using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class RegisterDrivingPracticeTests : SealedTests<RegisterEntity<RegisterDrivingPracticeData>>
    {
        private RegisterDrivingPracticeData data;
        private RegisterDrivingPractice registerDrivingPractice;
        private TeacherData teacherData;
        private ITeacherRepo teacherRepo;
        private DrivingPracticeData drivingPracticeData;
        private IDrivingPracticeRepo drivingPracticeRepo;
        protected override object createObject()
        {
            return new RegisterDrivingPractice(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<RegisterDrivingPracticeData>();
            teacherRepo = MockRepos.TeacherRepos(data.TeacherID, out teacherData);
            drivingPracticeRepo = MockRepos.DrivingPracticeRepos(data.DrivingPracticeID, out drivingPracticeData);
            base.TestInitialize();
            registerDrivingPractice = obj as RegisterDrivingPractice;
        }
        [TestMethod]
        public void TeacherIDTest() => isProperty(data.TeacherID);
        [TestMethod]
        public void DrivingPracticeIDTest() => isProperty(data.DrivingPracticeID);
        [TestMethod]
        public void TeacherTest()
        {
            isNull(registerDrivingPractice.Teacher);
            GetRepo.SetServiceProvider(new ServiceProviderMock(teacherRepo));
            var p = registerDrivingPractice.Teacher;
            isNotNull(p);
            areEqualProperties(teacherData, p.Data);
        }
        [TestMethod]
        public void DrivingPracticeTest()
        {
            isNull(registerDrivingPractice.DrivingPractice);
            GetRepo.SetServiceProvider(new ServiceProviderMock(drivingPracticeRepo));
            var p = registerDrivingPractice.DrivingPractice;
            isNotNull(p);
            areEqualProperties(drivingPracticeData, p.Data);
        }
    }
}
