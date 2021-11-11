using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class TeacherViewFactory : AbstractViewFactory<TeacherData, Teacher, TeacherView>
    {
        protected internal override Teacher toObject(TeacherData d) => new Teacher(d);
    }
}
