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
        private class MockStudentRepo : RepoMock<Student>, IStudentRepo { }
        protected override object createObject()
        {
            return new Teacher(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TeacherData>();
            createMockStudentRepo();
            base.TestInitialize();
        }
        private void createMockStudentRepo()
        {
            var count = GetRandom.UInt8(10, 20);
            var index = GetRandom.UInt8(0, count);
            var repo = new MockStudentRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<StudentData>();
                if (index == i)
                {
                    d.ID = data.StudentID;
                    studentData = d;
                }
                repo.Add(new Student(studentData)).GetAwaiter();
            }
            GetRepo.SetServiceProvider(new ServiceProviderMock(repo));
        }
        [TestMethod]
        public void StudentIDTest() => isProperty(data.StudentID);
        [TestMethod]
        public void StudentTest()
        {
            var p = (obj as Teacher).Student;
            isNotNull(p);
            areEqual(studentData.ID, p.ID);
        }
    }
}
