using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.Data
{
    public class StudentData : PersonData
    {

        public List<TheoryCourseData> TheoryCourse { get; set; }
        public List<PracticalCourseData> PracticalCourse { get; set; }
    }
}
