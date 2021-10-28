using Autokool.Data.Common;

namespace Autokool.Domain.Common
{

    public abstract class UniqueEntity<TData> : ValueObject<TData>, IUniqueEntity<TData> where
        TData : BaseData, new()
    {
        protected internal UniqueEntity(TData d = null) : base(d) { }

        public virtual string ID => Data?.ID ?? Unspecified;
    }
}
