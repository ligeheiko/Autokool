using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RegisterView : BaseView
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        [DisplayName("Course Name")]
        public string CourseID { get; set; }
        public bool IsRegisteredCourse { get; set; }
    }
}