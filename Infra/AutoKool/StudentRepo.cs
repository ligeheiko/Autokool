﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class StudentRepo : UniqueEntitiesRepo<Student, StudentData>,
      IStudentRepo
    {
        public StudentRepo(ApplicationDbContext c) : base(c, c.Students) { }
        protected internal override Student toDomainObject(StudentData d)
            => new Student(d);
    }
}