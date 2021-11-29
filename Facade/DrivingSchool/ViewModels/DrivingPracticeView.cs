using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public class DrivingPracticeView : DateView
    {
        [DisplayName("Teacher's Name")]
        public string TeacherID { get; set; }
    }
}
