using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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
        public async Task CourseTypeTest()
        {
            var repo = new RepoMock<CourseType>();
            var d = GetRandom.ObjectOf<CourseTypeData>();
            d.ID = data.CourseTypeID;
            await repo.Add(new CourseType(d));
            var p = (obj as Course).CourseType;
            isNotNull(p);
            areEqual(d.ID, p.ID);
            areEqual(d.DrivingCourse, p.DrivingCourse);
            areEqual(d.TheoryCourse, p.TheoryCourse);
        }
    }
}
