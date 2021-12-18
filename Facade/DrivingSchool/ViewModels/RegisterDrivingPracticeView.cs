using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RegisterDrivingPracticeView : RegisterView
    {
        [DisplayName("Teacher's Name")]
        public string TeacherID { get; set; }
    }
}
