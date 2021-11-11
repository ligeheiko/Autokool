using Autokool.Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public class CourseView : DateView
    {
        public string Location { get; set; }

        [DisplayName("Course Type")]
        public string CourseTypeID { get; set; }
    }
}
