using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Teacher : PersonEntity<TeacherData>
    {
        public Teacher(TeacherData d) : base(d) { }
        public string StudentID => Data?.StudentID ?? Unspecified;
    }
}
