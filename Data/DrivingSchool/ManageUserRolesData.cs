using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class ManageUserRolesData : NamedEntityData
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}