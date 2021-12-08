using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class GetRepoTests : BaseTests
    {
        private ICourseRepo courseRepo;
        private IExamRepo examRepo;
        private ITeacherRepo teacherRepo;
        private ServiceProviderMock provider;

        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(GetRepo);
            courseRepo = MockRepos.CourseRepos();
            examRepo = MockRepos.ExamRepos();
            teacherRepo = MockRepos.TeacherRepos();
            provider = new ServiceProviderMock(courseRepo, examRepo, teacherRepo);
            GetRepo.SetServiceProvider(null);
        }
        [TestMethod]
        public void SetServiceProviderTest()
        {
            isNull(GetRepo.services);
            GetRepo.SetServiceProvider(provider);
            Assert.AreSame(provider, GetRepo.services);
        }
        [TestMethod]
        public void InstanceTest()
        {
            GetRepo.SetServiceProvider(provider);
            var r = GetRepo.Instance(typeof(ICourseRepo));
            Assert.AreSame(r, courseRepo);
        }
        [TestMethod]
        public void InstanceByTypeTest()
        {
            GetRepo.SetServiceProvider(provider);
            var r = GetRepo.Instance<IExamRepo>();
            Assert.AreSame(r, examRepo);
        }
    }
}
