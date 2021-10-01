using Data.Common;

namespace Data
{
    public class SchoolData : BaseData
    {
        public AdministratorData Administrator { get; set; }
        public StudentData Student { get; set; }
        public TeacherData Teacher { get; set; }
        public CourseData Course { get; set; }

    }
}
