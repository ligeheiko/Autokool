using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;

namespace Autokool.Domain
{
    public sealed class PersonRole : UniqueEntity<PersonRoleData>
    {
        public PersonRole(PersonRoleData d = null) : base(d) { }
        public string PersonID { get; set; }
        public string RoleTypeID { get; set; }
    }
}
