using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Course : DateEntity<CourseData>
    {
        public Course(CourseData d) : base(d) { }
        public string Location => Data?.Location ?? Unspecified;
        public string CourseTypeID => Data?.CourseTypeID ?? Unspecified;
        public string RegisterCourseID => Data?.RegisterCourseID ?? Unspecified;
        public CourseType CourseType => new GetFrom<ICourseTypeRepo, CourseType>()?.ById(CourseTypeID);
        public RegisterCourse RegisterCourse => new GetFrom<IRegisterCourseRepo, RegisterCourse>()?.ById(RegisterCourseID);
    }
}