using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class TeacherViewFactory : AbstractViewFactory<TeacherData, Teacher, TeacherView>
    {
        protected internal override Teacher toObject(TeacherData d) => new Teacher(d);
        public override TeacherView Create(Teacher o)
        {
            var v = base.Create(o);
            v.FullName = o?.FirstName ?? "Unspecified" +" "+ o?.Name ?? "Unspecified";
            return v;
        }
    }
}