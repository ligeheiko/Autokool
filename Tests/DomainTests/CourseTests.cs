using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class CourseTests : SealedTests<DateEntity<CourseData>>
    {
        private CourseData data;
        protected override object createObject()
        {
            return new Course(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<CourseData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void LocationTest() => isProperty(data.Location);
        [TestMethod]
        public void CourseTypeIDTest() => isProperty(data.CourseTypeID);
        [TestMethod]
        public void CourseTypeTest()
        {
            notTested();
        }
    }
}
