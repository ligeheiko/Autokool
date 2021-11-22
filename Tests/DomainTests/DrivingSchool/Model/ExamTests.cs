using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class ExamTests : SealedTests<DateEntity<ExamData>>
    {
        private ExamData data;
        private ExamTypeData examTypeData;
        private IExamTypeRepo examTypeRepo;
        private Exam exam;
        protected override object createObject()
        {
            return new Exam(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ExamData>();
            examTypeRepo = MockRepos.ExamTypeRepos(data.ExamTypeID, out examTypeData);
            base.TestInitialize();
            exam = obj as Exam;
        }
        [TestMethod]
        public void PassedTest() => isProperty(data.Passed);
        [TestMethod]
        public void ExamTypeIDTest() => isProperty(data.ExamTypeID);
        [TestMethod]
        public void ExamTypeTest()
        {
            isNull((exam).ExamType);
            GetRepo.SetServiceProvider(new ServiceProviderMock(examTypeRepo));
            var p = (exam).ExamType;
            isNotNull(p);
            areEqual(examTypeData.ID, p.ID);
        }
    }
}
