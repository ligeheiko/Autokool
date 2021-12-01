using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using System.ComponentModel.DataAnnotations;

namespace Autokool.Domain.Common
{
    public abstract class PersonEntity<TData> : DateEntity<TData>
        where TData : PersonData, new()
    {
        protected PersonEntity(TData d = null) : base(d) { }

        public string FirstName => Data?.FirstName ?? Unspecified;
        public string LastName => Data?.LastName ?? Unspecified;
        public string Email => Data?.Email ?? Unspecified;
        public string PhoneNr => Data?.PhoneNr ?? Unspecified;
        public string RoleTypeID => Data?.RoleTypeID ?? Unspecified;
        public RoleType RoleType => new GetFrom<IRoleTypeRepo, RoleType>().ById(RoleTypeID);
        public string FullName => $"{FirstName} {Name}";
    }
}
