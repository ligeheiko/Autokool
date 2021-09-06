using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.Data
{
    public class SchoolData
    {
        public PracticalCourseData PracticalCourse { get; set; }
        public TheoryCourseData TheoryCourse { get; set; }
        public StudentData Student { get; set; }
        public TeacherData Teacher { get; set; }
    }
}
