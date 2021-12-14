using Autokool.Facade.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class CourseView : DateView
    {
        public string Location { get; set; }

        [DisplayName("Course Type")]
        public string CourseTypeID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Added")]
        public new DateTime? ValidFrom { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd HH:mm}")]
        [DisplayName("Every week at")]
        public new DateTime? ValidTo { get; set; }
        [DisplayName("RegisterID")]
        public string RegisterID { get; set; }
    }
}
