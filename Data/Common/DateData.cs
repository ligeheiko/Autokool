using System;


namespace Autokool.Data.Common
{
    public abstract class DateData : NamedEntityData
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
