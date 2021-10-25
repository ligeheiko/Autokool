using Autokool.Core;
using System;

namespace Autokool.Domain.Common
{
    public abstract class DateEntity<TData> : BaseEntity<TData> where 
        TData : class, IDateEntityData, new()
    {
        protected DateEntity() : this(null){}
        protected DateEntity(TData d) : base(d) { }
        public DateTime ValidFrom => Data?.ValidFrom ?? DateTime.MinValue;
        public DateTime ValidTo => Data?.ValidTo ?? DateTime.MaxValue;
    }
}
