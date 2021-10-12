using Autokool.Data.Common;
using System.Collections.Generic;

namespace Autokool.Data.DrivingSchool
{
    public sealed class TeacherData : PersonData
    {
        public List<StudentData> Student { get; set; }
    }
}
