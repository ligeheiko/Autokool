using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class StudentTests : SealedTests<PersonEntity<StudentData>>
    {
        private StudentData data;
        private CourseData courseData;
        private MockCourseRepo courseRepo;
        private Student student;
        private class MockCourseRepo : RepoMock<Course>, ICourseRepo { }
        protected override object createObject()
        {
            return new Student(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<StudentData>();
            courseRepo = createMockCourseRepo();
            base.TestInitialize();
            student = obj as Student;
        }
        private MockCourseRepo createMockCourseRepo()
            =>createMockRepo<MockCourseRepo, Course, CourseData>
            (data.CourseID, d => new Course(d), out courseData);
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
        [TestMethod]
        public void CourseTest()
        {
            isNull((student).Course);
            GetRepo.SetServiceProvider(new ServiceProviderMock(courseRepo));
            var p = (student).Course;
            isNotNull(p);
            areEqualProperties(courseData, p.Data);
        }
    }
}
