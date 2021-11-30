using Autokool.Facade.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public class DrivingPracticeView : DateView
    {
        [DisplayName("Teacher's Name")]
        public string TeacherID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Display(Name = "Ends")]
        public new DateTime ValidTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Starts")]
        public new DateTime ValidFrom { get; set; }
    }
}
