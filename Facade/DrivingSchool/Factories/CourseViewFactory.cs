using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class CourseViewFactory : AbstractViewFactory<CourseData, Course, CourseView>
    {
        protected internal override Course toObject(CourseData d) => new Course(d);
    }
}
