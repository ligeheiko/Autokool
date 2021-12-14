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
        public string RegisterID => Data?.RegisterID ?? Unspecified;
        public CourseType CourseType => new GetFrom<ICourseTypeRepo, CourseType>()?.ById(CourseTypeID);
        public Register Register => new GetFrom<IRegisterRepo, Register>()?.ById(CourseTypeID);
    }
}
