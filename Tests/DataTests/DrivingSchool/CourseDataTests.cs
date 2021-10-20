using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void LocationTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void CourseTypeIDTest()
        {
            isProperty<string>();
        }
    }
}
