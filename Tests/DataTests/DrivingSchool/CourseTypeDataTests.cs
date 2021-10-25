using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseTypeDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void IDTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void TheoryCourseTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void DrivingCourseTest()
        {
            isProperty<string>();
        }
    }
}
