using Autokool.Facade.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public class CourseView : DateView
    {
        public string Location { get; set; }

        [DisplayName("Course Type")]
        public string CourseTypeID { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd HH:mm}")]
        [Display(Name = "Every week at")]
        public new DateTime ValidTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Added")]
        public new DateTime ValidFrom { get; set; }
    }
}
