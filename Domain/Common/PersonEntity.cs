using Autokool.Data.Common;

namespace Autokool.Domain.Common
{
    public abstract class PersonEntity<TData> : DateEntity<TData>
        where TData : PersonData, new()
    {
        protected PersonEntity(TData d = null) : base(d) { }

        public string FirstName => Data?.FirstName;
        public string LastName => Data?.LastName;
        public string Email => Data?.Email;
        public string PhoneNr => Data?.PhoneNr;
    }
}
