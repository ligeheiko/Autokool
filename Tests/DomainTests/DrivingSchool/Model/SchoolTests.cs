using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class SchoolTests : SealedTests<UniqueEntity<SchoolData>>
    {
        private SchoolData data;
        private CourseData courseData;
        private ICourseRepo courseRepo;
        private School school;
        protected override object createObject()
        {
            return new School(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<SchoolData>();
            courseRepo = MockRepos.CourseRepos(data.CourseID, out courseData);
            base.TestInitialize();
            school = obj as School;
        }
        [TestMethod]
        public void AdministratorIDTest() => isProperty(data.AdministratorID);
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
        [TestMethod]
        public void StudentIDTest() => isProperty(data.StudentID);
        [TestMethod]
        public void TeacherIDTest() => isProperty(data.TeacherID);
        [TestMethod]
        public void CourseTest()
        {
            isNull(school.Course);
            GetRepo.SetServiceProvider(new ServiceProviderMock(courseRepo));
            var p = school.Course;
            isNotNull(p);
            areEqualProperties(courseData, p.Data);
        }
    }
}
