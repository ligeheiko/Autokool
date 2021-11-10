using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class CourseType : NamedEntity<CourseTypeData>
    {
        public CourseType(CourseTypeData d) : base(d) { }
    }
}