using Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class CourseTypeView : BaseView
    {
        [DisplayName("Theory Course")]
        public string TheoryCourse { get; set; }
        [DisplayName("Driving Course")]
        public string DrivingCourse { get; set; }
    }
}
