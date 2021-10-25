using Autokool.Data.Common;
using Autokool.Core;

namespace Autokool.Domain.Common
{
    public abstract class Person<TData> : DateEntity<TData>,
        IPersonEntity where TData : PersonData, new()
    {
        protected Person() : this(null) { }
        protected Person(TData d) : base(d) { }

        public string FirstName => Data?.FirstName;
        public string LastName => Data?.LastName;
        public string Email => Data?.Email;
        public string PhoneNr => Data?.PhoneNr;
    }

    public interface IPersonEntity : IBaseEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNr { get; }
    }
}
