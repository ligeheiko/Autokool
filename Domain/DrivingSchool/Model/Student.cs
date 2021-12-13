using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Student : PersonEntity<StudentData>
    {
        public Student(StudentData d) : base(d) { }
        public string CourseID => Data?.CourseID ?? Unspecified;
        public Course Course => new GetFrom<ICourseRepo, Course>().ById(CourseID);
    }
}