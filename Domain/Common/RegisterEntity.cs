using Autokool.Data.Common;

namespace Autokool.Domain.Common
{
    public abstract class RegisterEntity<TData> : UniqueEntity<TData>, IRegisterEntity<TData>
        where TData : RegisterData, new()
    {
        public RegisterEntity(TData d = null) : base(d) { }
        public bool IsRegistered => Data?.IsRegistered ?? false;
        public string UserId => Data?.UserId ?? Unspecified;
        public string UserName => Data?.UserName ?? Unspecified;
    }
}