using Autokool.Core;
using System;


namespace Autokool.Data.Common
{
    public abstract class DateData : BaseData,IDateEntityData
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
