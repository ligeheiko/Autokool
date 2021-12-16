using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class CourseTests : SealedTests<DateEntity<CourseData>>
    {
        private CourseData data;
        private CourseTypeData courseTypeData;
        private RegisterCourseData registerCourseData;
        private ICourseTypeRepo courseTypeRepo;
        private IRegisterCourseRepo registerCourseRepo;
        private Course course;

        protected override object createObject()
        {
            return new Course(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<CourseData>();
            courseTypeRepo = MockRepos.CourseTypeRepos(data.CourseTypeID, out courseTypeData);
            registerCourseRepo = MockRepos.RegisterCourseRepos(data.RegisterCourseID, out registerCourseData);
            base.TestInitialize();
            course = obj as Course;
        }

        [TestMethod]
        public void LocationTest() => isProperty(data.Location);
        [TestMethod]
        public void CourseTypeIDTest() => isProperty(data.CourseTypeID);
        [TestMethod]
        public void RegisterCourseIDTest() => isProperty(data.RegisterCourseID);
        [TestMethod]
        public void CourseTypeTest()
        {
            isNull(course.CourseType);
            GetRepo.SetServiceProvider(new ServiceProviderMock(courseTypeRepo));
            var p = course.CourseType;
            isNotNull(p);
            areEqualProperties(courseTypeData, p.Data);
        }
        [TestMethod]
        public void RegisterCourseTest()
        {
            isNull(course.RegisterCourse);
            GetRepo.SetServiceProvider(new ServiceProviderMock(registerCourseRepo));
            var p = course.RegisterCourse;
            isNotNull(p);
            areEqualProperties(registerCourseData, p.Data);
        }
    }
}
