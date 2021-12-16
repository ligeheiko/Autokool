using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class RegisterCourseViewFactory: AbstractViewFactory<RegisterCourseData, RegisterCourse, RegisterCourseView>
    {
        protected internal override RegisterCourse toObject(RegisterCourseData d) => new RegisterCourse(d);
    }
}