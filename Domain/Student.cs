using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Repos;

namespace Autokool.Domain
{
    public sealed class Student : Person<StudentData>
    {
        public Student(StudentData d) : base(d) { }
        public string CourseID => Data.CourseID;
        public Course Course => new GetFrom<ICourseRepo, Course>().ById(CourseID);
    }
}
