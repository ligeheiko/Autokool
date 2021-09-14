using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class PracticalCourseData : CourseData
    {
        public StudentData Student { get; set; }
        public TeacherData Teacher { get; set; }
    }
}
