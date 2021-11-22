using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class TeacherTests : SealedTests<PersonEntity<TeacherData>>
    {
        private StudentData studentData;
        private TeacherData data;
        private IStudentRepo studentRepo;
        private Teacher teacher;
        protected override object createObject()
        {
            return new Teacher(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TeacherData>();
            studentRepo = MockRepos.StudentRepos(data.StudentID, out studentData);
            base.TestInitialize();
            teacher = obj as Teacher;
        }
        [TestMethod]
        public void StudentIDTest() => isProperty(data.StudentID);
        [TestMethod]
        public void StudentTest()
        {
            isNull(teacher.Student);
            GetRepo.SetServiceProvider(new ServiceProviderMock(studentRepo));
            var p = teacher.Student;
            isNotNull(p);
            areEqualProperties(studentData, p.Data);
        }
    }
}
