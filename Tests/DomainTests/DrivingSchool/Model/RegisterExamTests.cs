using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class RegisterExamTests : SealedTests<RegisterEntity<RegisterExamData>>
    {
        private RegisterExamData data;
        private ExamData examData;
        private IExamRepo examRepo;
        private RegisterExam registerExam;
        protected override object createObject()
        {
            return new RegisterExam(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<RegisterExamData>();
            examRepo = MockRepos.ExamRepos(data.ExamID, out examData);
            base.TestInitialize();
            registerExam = obj as RegisterExam;
        }
        [TestMethod]
        public void ExamIDTest() => isProperty(data.ExamID);
        [TestMethod]
        public void ExamTest()
        {
            isNull(registerExam.Exam);
            GetRepo.SetServiceProvider(new ServiceProviderMock(examRepo));
            var p = registerExam.Exam;
            isNotNull(p);
            areEqualProperties(examData, p.Data);
        }
    }
}