using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class RegisterCourse : RegisterEntity<RegisterCourseData>
    {
        public RegisterCourse(RegisterCourseData d) : base(d) { }
        public string CourseID => Data?.CourseID ?? Unspecified;
        public Course Course => new GetFrom<ICourseRepo, Course>()?.ById(CourseID);
    }
}