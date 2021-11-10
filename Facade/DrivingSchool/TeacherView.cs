using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Data.DrivingSchool
{
    public sealed class TeacherView : PersonView
    {
        [DisplayName("Student")]
        public string StudentID { get; set; }
    }
}
