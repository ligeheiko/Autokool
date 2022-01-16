using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class CourseTypeViewFactory : AbstractViewFactory<CourseTypeData, CourseType, CourseTypeView>
    {
        protected internal override CourseType toObject(CourseTypeData d) => new (d);
    }
}
