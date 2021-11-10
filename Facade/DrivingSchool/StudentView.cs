using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Data.DrivingSchool
{
    public sealed class StudentView : PersonView
    {
        [DisplayName("Course")]
        public string CourseID { get; set; }
    }
}
