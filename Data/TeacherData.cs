using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class TeacherData : PersonData
    {
        public List<StudentData> Student { get; set; }
    }
}
