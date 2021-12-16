using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RegisterCourseView : RegisterView
    {
        [DisplayName("Course Name")]
        public string CourseID { get; set; }
    }
}