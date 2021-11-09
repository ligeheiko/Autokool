﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class CourseType : NamedEntity<CourseTypeData>
    {
        public CourseType(CourseTypeData d) : base(d) { }
    }
}