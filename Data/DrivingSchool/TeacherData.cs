using Autokool.Data.Common;
using System.Collections.Generic;

namespace Autokool.Data.DrivingSchool
{
    public class TeacherData : PersonData
    {
        public List<StudentData> Student { get; set; }
    }
}
