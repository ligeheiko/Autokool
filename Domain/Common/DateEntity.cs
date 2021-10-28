using Autokool.Data.Common;
using System;

namespace Autokool.Domain.Common
{
    public abstract class DateEntity<TData> : UniqueEntity<TData>, IDateEntity<TData> where 
        TData : DateData, new()
    {
        protected DateEntity(TData d = null) : base(d) { }
        public DateTime ValidFrom => Data?.ValidFrom ?? DateTime.MinValue;
        public DateTime ValidTo => Data?.ValidTo ?? DateTime.MaxValue;
    }
}
