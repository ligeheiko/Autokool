using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.Factories;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class StudentView : PersonView
    {
        [DisplayName("Course")]
        public string CourseID { get; set; }
    }
}
