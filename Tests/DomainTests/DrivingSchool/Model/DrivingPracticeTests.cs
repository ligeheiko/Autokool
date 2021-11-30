using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class DrivingPracticeTests : SealedTests<DateEntity<DrivingPracticeData>>
    {
        private DrivingPracticeData data;
        private TeacherData teacherData;
        private ITeacherRepo teacherRepo;
        private DrivingPractice drivingPractice;
        protected override object createObject()
        {
            return new DrivingPractice(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<DrivingPracticeData>();
            teacherRepo = MockRepos.TeacherRepos(data.TeacherID, out teacherData);
            base.TestInitialize();
            drivingPractice = obj as DrivingPractice;
        }
        [TestMethod]
        public void TeacherIDTest() => isProperty(data.TeacherID);
        [TestMethod]
        public void TeacherTest()
        {
            isNull(drivingPractice.Teacher);
            GetRepo.SetServiceProvider(new ServiceProviderMock(teacherRepo));
            var p = drivingPractice.Teacher;
            isNotNull(p);
            areEqualProperties(teacherData, p.Data);
        }
    }
}
