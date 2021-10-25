using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class SchoolData : BaseData
    {
        public AdministratorData Administrator { get; set; }
        public StudentData Student { get; set; }
        public TeacherData Teacher { get; set; }
        public CourseData Course { get; set; }
    }
}
