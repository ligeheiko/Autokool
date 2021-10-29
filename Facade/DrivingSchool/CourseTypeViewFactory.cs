using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class CourseTypeViewFactory : AbstractViewFactory<CourseTypeData, CourseType, CourseTypeView>
    {
        protected internal override CourseType toObject(CourseTypeData d) => new CourseType(d);
    }
}
