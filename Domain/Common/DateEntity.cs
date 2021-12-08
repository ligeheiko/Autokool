using Autokool.Data.Common;
using System;

namespace Autokool.Domain.Common
{
    public abstract class DateEntity<TData> : NamedEntity<TData>, IDateEntity<TData> where 
        TData : DateData, new()
    {
        protected DateEntity(TData d = null) : base(d) { }
        public DateTime ValidFrom => Data?.ValidFrom ?? UnspecifiedValidFrom;
        public DateTime ValidTo => Data?.ValidTo ?? UnspecifiedValidTo;
    }
}
