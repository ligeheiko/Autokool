using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;

namespace Autokool.Domain
{
    public sealed class Course : DateEntity<CourseData>
    {
        public Course(CourseData d) : base(d) { }
        public string Location => Data?.Location ?? "Unspecified";
        public string CourseTypeID => Data?.CourseTypeID ?? "Unspecified";
        public CourseType CourseType => new GetFrom<ICourseTypeRepo, CourseType>().ById(CourseTypeID);
    }
}
