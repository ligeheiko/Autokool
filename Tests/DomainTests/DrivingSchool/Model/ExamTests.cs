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
        private MockExamTypeRepo examTypeRepo;
        private Exam exam;
        private class MockExamTypeRepo : RepoMock<ExamType>, IExamTypeRepo { }
        protected override object createObject()
        {
            return new Exam(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ExamData>();
            examTypeRepo = createMockExamTypeRepo();
            base.TestInitialize();
            exam = obj as Exam;
        }
        private MockExamTypeRepo createMockExamTypeRepo()
            => createMockRepo<MockExamTypeRepo, ExamType, ExamTypeData>
            (data.ExamTypeID, d => new ExamType(d), out examTypeData);
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
