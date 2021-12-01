using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class StudentViewFactory : PersonViewFactory<StudentData, Student, StudentView>
    {
        protected internal override Student toObject(StudentData d) => new Student(d);

        public override string GetName(StudentView v, Student o)
        {
            return v.FullName = o.FirstName + " " + o.Name;
        }
    }
}
