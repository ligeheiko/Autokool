using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class GetFromTests : SealedTests<object>
    {
        protected override object createObject()
        {
            return new GetFrom<ICourseRepo, Course>();
        }
        private string ID;
        private ICourseRepo courseRepo;
        private ServiceProviderMock provider;
        private CourseData courseData;
        [TestInitialize]
        public override void TestInitialize()
        {
            type = typeof(GetRepo);
            ID = GetRandom.String();
            courseRepo = MockRepos.CourseRepos(ID, out courseData);
            provider = new ServiceProviderMock(courseRepo);
            GetRepo.SetServiceProvider(provider);
            base.TestInitialize();
        }
        [TestMethod]
        public void ByIdTest()
        {
            var o = new GetFrom<ICourseRepo, Course>().ById(ID);
            areEqualProperties(courseData, o.Data);
        }
        [TestMethod]
        public void ListByTest()
        {
            var l = new GetFrom<ICourseRepo, Course>().ListBy(nameof(courseData.Name), courseData.Name);
            areEqual(1, l.Count);
            areEqualProperties(courseData, l[0].Data);
        }
        [TestMethod]
        public void ListBySearchStringTest()
        {
            var l = new GetFrom<ICourseRepo, Course>().ListBy(null, null, null);
            areEqual(courseRepo.Get().GetAwaiter().GetResult().Count, l.Count);
        }
    }
}
