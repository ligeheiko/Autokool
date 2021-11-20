using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Teacher : PersonEntity<TeacherData>
    {
        public Teacher(TeacherData d) : base(d) { }
        public string StudentID => Data?.StudentID ?? Unspecified;
        public Student Student => new GetFrom<IStudentRepo, Student>().ById(StudentID);
    }
}
