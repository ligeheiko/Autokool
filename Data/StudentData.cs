﻿using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class StudentData : PersonData
    {
        public CourseData Course { get; set; }
    }
}
