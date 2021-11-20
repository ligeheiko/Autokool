using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;

namespace Autokool.Domain.DrivingSchool.Model
{
    //TODO teha 2 FKga mitte uniqueID
    // POle kindel kas vaja
    public sealed class PersonRole : UniqueEntity<PersonRoleData>
    {
        public PersonRole(PersonRoleData d = null) : base(d) { }
        public string PersonID => Data?.PersonID ?? Unspecified;
        public string RoleTypeID => Data?.RoleTypeID ?? Unspecified;
       
    }
}
