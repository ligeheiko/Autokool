using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autokool.Domain.DrivingSchool.Model
{
    public class UserRoles : UniqueEntity<UserRolesData>
    {
        public UserRoles(UserRolesData d) : base(d) { }
        public string UserId => Data?.UserId ?? Unspecified;
        public string FirstName => Data?.FirstName ?? Unspecified;
        public string LastName => Data?.LastName ?? Unspecified;
        public string UserName => Data?.UserName ?? Unspecified;
        public string Email => Data?.Email ?? Unspecified;
        [NotMapped]
        public IEnumerable<string> Roles => Data?.Roles ?? default;
    }
}
