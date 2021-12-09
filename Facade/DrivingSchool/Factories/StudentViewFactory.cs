﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class StudentViewFactory : AbstractViewFactory<StudentData, Student, StudentView>
    {
        protected internal override Student toObject(StudentData d) => new Student(d);

        public override StudentView Create(Student o)
        {
            var v = base.Create(o);
            v.FullName = o.FirstName + " " + o.LastName;
            return v;
        }
    }
}
