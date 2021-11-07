using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class CourseTests : SealedTests<DateEntity<CourseData>>
    {
        private CourseData data;
        private CourseTypeData courseTypeData;

        private class MockCourseTypeRepo : RepoMock<CourseType>, ICourseTypeRepo { }
        protected override object createObject()
        {
            return new Course(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<CourseData>();
            createMockCourseTypeRepo();
            base.TestInitialize();
        }

        private void createMockCourseTypeRepo()
        {
            var count = GetRandom.UInt8(10, 20);
            var index = GetRandom.UInt8(0, count);
            var repo = new MockCourseTypeRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<CourseTypeData>();
                if (index == i)
                {
                    d.ID = data.CourseTypeID;
                    courseTypeData = d;
                }
                repo.Add(new CourseType(courseTypeData)).GetAwaiter();
            }
            GetRepo.SetServiceProvider(new ServiceProviderMock(repo));
        }

        [TestMethod]
        public void LocationTest() => isProperty(data.Location);
        [TestMethod]
        public void CourseTypeIDTest() => isProperty(data.CourseTypeID);
        [TestMethod]
        public void CourseTypeTest()
        {
            var p = (obj as Course).CourseType;
            isNotNull(p);
            areEqual(courseTypeData.ID, p.ID);
            areEqual(courseTypeData.DrivingCourse, p.DrivingCourse);
            areEqual(courseTypeData.TheoryCourse, p.TheoryCourse);
        }
        [TestMethod]
        public void CourseTypeIsNullTest()
        {
            GetRepo.SetServiceProvider(null);
            isNull((obj as Course).CourseType);
        }
    }
}
