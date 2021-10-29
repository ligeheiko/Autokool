using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class StudentViewFactory : AbstractViewFactory<StudentData, Student, StudentView>
    {
        protected internal override Student toObject(StudentData d) => new Student(d);
    }
}
