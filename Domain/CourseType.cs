using Autokool.Core;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class CourseType : BaseEntity<CourseTypeData>
    {
        public CourseType(CourseTypeData d) : base(d) { }
        public string TheoryCourse => Data?.TheoryCourse ?? "Unspecified";
        public string DrivingCourse => Data?.DrivingCourse ?? "Unspecified";
    }
}