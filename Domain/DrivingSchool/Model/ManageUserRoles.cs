using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class ManageUserRoles : UniqueEntity<ManageUserRolesData>
    {
        public ManageUserRoles(ManageUserRolesData d) : base(d) { }
        public string RoleId => Data?.RoleId ?? Unspecified;
        public string RoleName => Data?.RoleName ?? Unspecified;
        public bool Selected => Data.Selected;
    }
}
