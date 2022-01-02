using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.Common
{
    public abstract class PersonEntity<TData> : DateEntity<TData>
        where TData : PersonData, new()
    {
        protected PersonEntity(TData d = null) : base(d) { }
        public string FirstName => Data?.FirstName ?? Unspecified;
        public string Email => Data?.Email ?? Unspecified;
        public string PhoneNr => Data?.PhoneNr ?? Unspecified;
        public string FullName => $"{FirstName} {Name}";
    }
}