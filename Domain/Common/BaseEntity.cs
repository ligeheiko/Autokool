using Autokool.Aids;
using Autokool.Core;
using System;

namespace Autokool.Domain.Common
{
    public abstract class BaseEntity<TData> : IBaseEntity  where TData
        : class , IEntityData, new ()
    {
        private readonly TData data;
        protected BaseEntity() : this(null) { }
        public BaseEntity(TData d) => data = d;
        public TData Data => Copy.Members(data, new TData()) ?? new TData();
        public string ID => Data?.ID ?? "Unspecified";
    }
}
