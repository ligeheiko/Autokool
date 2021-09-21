using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class SchoolData : BaseData
    {
        public AdministratorData Administrators { get; set; }
        public StudentData Students { get; set; }
        public TeacherData Teachers { get; set; }
        public CourseData Courses { get; set; }

    }
}
