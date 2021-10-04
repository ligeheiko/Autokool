using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseDataTests : BaseTests<CourseData, BaseData>
    {
        [TestMethod]
        public void LocationTest()
        {
            TestProperty<string>(nameof(obj.Location));
        }
        [TestMethod]
        public void ClassTypesTest()
        {
            TestProperty<string>(nameof(obj.CourseTypeID));
        }
    }
}
