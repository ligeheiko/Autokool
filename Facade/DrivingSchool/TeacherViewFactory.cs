using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class TeacherViewFactory : AbstractViewFactory<TeacherData, Teacher, TeacherView>
    {
        protected internal override Teacher toObject(TeacherData d) => new Teacher(d);
    }
}
