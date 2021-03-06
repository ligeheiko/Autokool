using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Facade.Common
{
    public abstract class DateView : NamedView
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }
    }
}
