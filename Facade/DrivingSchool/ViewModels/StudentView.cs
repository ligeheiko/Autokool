using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class StudentView : PersonView
    {
        [DisplayName("Course")]
        public string CourseID { get; set; }
        [DisplayName("Last Name")]
        public new string Name { get; set; }
    }
}
