﻿using Autokool.Facade.Common;
using Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public class CourseView : DateView
    {
        public string Location { get; set; }

        [DisplayName("Course")]
        public string CourseTypeID { get; set; }

        [DisplayName("Course")]
        public string CourseName { get; set; }
    }
}