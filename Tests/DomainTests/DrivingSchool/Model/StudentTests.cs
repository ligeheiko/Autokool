using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    //TODO createRepo teha abstraktseks kuskil baas klassis
    [TestClass]
    public class StudentTests : SealedTests<PersonEntity<StudentData>>
    {
        private StudentData data;
        private CourseData courseData;
        private class MockCourseRepo : RepoMock<Course>, ICourseRepo { }
        protected override object createObject()
        {
            return new Student(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<StudentData>();
            createMockCourseRepo();
            base.TestInitialize();
        }
        private void createMockCourseRepo()
        {
            var count = GetRandom.UInt8(10, 20);
            var index = GetRandom.UInt8(0, count);
            var repo = new MockCourseRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<CourseData>();
                if (index == i)
                {
                    d.ID = data.CourseID;
                    courseData = d;
                }
                repo.Add(new Course(courseData)).GetAwaiter();
            }
            GetRepo.SetServiceProvider(new ServiceProviderMock(repo));
        }
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
        [TestMethod]
        public void CourseTest()
        {
            var p = (obj as Student).Course;
            isNotNull(p);
            areEqual(courseData.ID, p.ID);
        }
        [TestMethod]
        public void CourseIsNullTest()
        {
            GetRepo.SetServiceProvider(null);
            isNull((obj as Student).Course);
        }
    }
}
