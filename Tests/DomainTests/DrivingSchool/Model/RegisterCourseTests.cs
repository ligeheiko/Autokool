using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class RegisterCourseTests : SealedTests<RegisterEntity<RegisterCourseData>>
    {
        private RegisterCourseData data;
        private CourseData courseData;
        private ICourseRepo courseRepo;
        private RegisterCourse registerCourse;
        protected override object createObject()
        {
            return new RegisterCourse(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<RegisterCourseData>();
            courseRepo = MockRepos.CourseRepos(data.CourseID, out courseData);
            base.TestInitialize();
            registerCourse = obj as RegisterCourse;
        }
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
        [TestMethod]
        public void CourseTest()
        {
            isNull(registerCourse.Course);
            GetRepo.SetServiceProvider(new ServiceProviderMock(courseRepo));
            var p = registerCourse.Course;
            isNotNull(p);
            areEqualProperties(courseData, p.Data);
        }
    }
}