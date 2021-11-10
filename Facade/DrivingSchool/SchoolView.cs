using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class SchoolView : BaseView
    {
        [DisplayName("Admin")]
        public string AdministratorID { get; set; }
        [DisplayName("Student")]
        public string StudentID { get; set; }
        [DisplayName("Teacher")]
        public string TeacherID { get; set; }
        [DisplayName("Course")]
        public string CourseID { get; set; }
    }
}
