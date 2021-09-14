using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class StudentData : PersonRoleData
    {

        public List<TheoryCourseData> TheoryCourse { get; set; }
        public List<PracticalCourseData> PracticalCourse { get; set; }
    }
}
