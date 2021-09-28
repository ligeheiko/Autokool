using Contoso.Aids;
using Core;
using System;

namespace Domain.Common
{
    public class BaseEntity<TData>  where TData
        : class , IEntityData, new ()
    {
        private readonly TData data;
        protected BaseEntity() : this(null) { }
        public BaseEntity(TData d) => data = d;
        public TData Data => Copy.Members(data, new TData()) ?? new TData();
        public string ID => Data?.ID;
        public DateTime ValidFrom => Data.ValidFrom;
        public DateTime ValidTo => Data.ValidTo;
    }
}
