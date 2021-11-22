using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class School : UniqueEntity<SchoolData>
    {
        public School(SchoolData d) : base(d) { }
        public string AdministratorID => Data?.AdministratorID ?? Unspecified;
        public string StudentID => Data?.StudentID ?? Unspecified;
        public string TeacherID => Data?.TeacherID ?? Unspecified;
        public string CourseID => Data?.CourseID ?? Unspecified;
        public Course Course => new GetFrom<ICourseRepo, Course>().ById(CourseID);
    }
}
