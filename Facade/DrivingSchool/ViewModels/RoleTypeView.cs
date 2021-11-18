using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RoleTypeView : NamedView
    {
        [DisplayName("Admin")]
        public string AdministratorID { get; set; }
        [DisplayName("Student")]
        public string StudentID { get; set; }
        [DisplayName("Teacher")]
        public string TeacherID { get; set; }
    }
}
