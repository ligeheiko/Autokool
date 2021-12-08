using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class ManageUserRoles : NamedEntity<ManageUserRolesData>
    {
        public ManageUserRoles(ManageUserRolesData d) : base(d) { }
        public string RoleId => Data?.RoleId ?? Unspecified;
        public string RoleName => Data?.RoleName ?? Unspecified;
        public bool Selected => Data?.Selected ?? false;
    }
}
