using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Common
{
    public class BaseView
    {
        public string ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }
    }
}
