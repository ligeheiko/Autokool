using Autokool.Facade.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class ExamView : DateView
    {
        public bool Passed { get; set; }

        [DisplayName("Exam Type")]
        public string ExamTypeID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisplayName("Starts")]
        public new DateTime? ValidTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Added")]
        public new DateTime? ValidFrom { get; set; }
    }
}
