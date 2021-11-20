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
        private MockStudentRepo studentRepo;
        private Teacher teacher;
        private class MockStudentRepo : RepoMock<Student>, IStudentRepo { }
        protected override object createObject()
        {
            return new Teacher(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TeacherData>();
            studentRepo = createMockStudentRepo();
            base.TestInitialize();
            teacher = obj as Teacher;
        }
        private MockStudentRepo createMockStudentRepo() 
            =>createMockRepo<MockStudentRepo, Student, StudentData>
            (data.StudentID, d => new Student(d), out studentData);
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
