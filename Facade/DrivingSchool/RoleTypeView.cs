using Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class RoleTypeView : BaseView
    {
        [DisplayName("Admin")]
        public string AdministratorID { get; set; }
        [DisplayName("Student")]
        public string StudentID { get; set; }
        [DisplayName("Teacher")]
        public string TeacherID { get; set; }
    }
}
