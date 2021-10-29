using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class SchoolData : BaseData
    {
        public string AdministratorID { get; set; }
        public string StudentID { get; set; }
        public string TeacherID { get; set; }
        public string CourseID { get; set; }
    }
}
