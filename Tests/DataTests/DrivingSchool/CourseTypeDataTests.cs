using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseTypeDataTests : BaseTests<CourseTypeData, object>
    {
        [TestMethod]
        public void IDTest()
        {
            TestProperty<string>(nameof(obj.ID));
        }
        [TestMethod]
        public void TheoryCourseTest()
        {
            TestProperty<string>(nameof(obj.TheoryCourse));
        }
        [TestMethod]
        public void DrivingCourseTest()
        {
            TestProperty<string>(nameof(obj.DrivingCourse));
        }
    }
}
