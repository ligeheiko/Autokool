using Data.Common;
using System.Collections.Generic;

namespace Data
{
    public class TeacherData : PersonData
    {
        public List<StudentData> Student { get; set; }
    }
}
