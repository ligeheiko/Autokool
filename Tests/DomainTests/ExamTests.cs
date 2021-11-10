using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class ExamTests : SealedTests<DateEntity<ExamData>>
    {
        private ExamData data;
        private ExamTypeData examTypeData;
        private class MockExamTypeRepo : RepoMock<ExamType>, IExamTypeRepo { }
        protected override object createObject()
        {
            return new Exam(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<ExamData>();
            createMockExamTypeRepo();
            base.TestInitialize();
        }
        private void createMockExamTypeRepo()
        {
            var count = GetRandom.UInt8(10, 20);
            var index = GetRandom.UInt8(0, count);
            var repo = new MockExamTypeRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<ExamTypeData>();
                if (index == i)
                {
                    d.ID = data.ExamTypeID;
                    examTypeData = d;
                }
                repo.Add(new ExamType(examTypeData)).GetAwaiter();
            }
            GetRepo.SetServiceProvider(new ServiceProviderMock(repo));
        }
        [TestMethod]
        public void PassedTest() => isProperty(data.Passed);
        [TestMethod]
        public void ExamTypeIDTest() => isProperty(data.ExamTypeID);
        [TestMethod]
        public void ExamTypeTest()
        {
            var p = (obj as Exam).ExamType;
            isNotNull(p);
            areEqual(examTypeData.ID, p.ID);
        }
        [TestMethod]
        public void ExamTypeIsNullTest()
        {
            GetRepo.SetServiceProvider(null);
            isNull((obj as Exam).ExamType);
        }
    }
}
