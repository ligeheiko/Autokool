using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class TeacherView : PersonView
    {
        [DisplayName("Student")]
        public string StudentID { get; set; }

        [DisplayName("Last Name")]
        public new string Name { get; set; }
    }
}