﻿using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class StudentData : PersonData
    {
        public CourseData Course { get; set; }
    }
}
