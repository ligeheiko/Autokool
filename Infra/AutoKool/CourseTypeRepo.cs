﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class CourseTypeRepo : UniqueEntitiesRepo<CourseType, CourseTypeData>,
      ICourseTypeRepo
    {
        public CourseTypeRepo(ApplicationDbContext c) : base(c, c.CourseTypes) { }
        protected internal override CourseType toDomainObject(CourseTypeData d)
            => new CourseType(d);
    }
}