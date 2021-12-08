using Autokool.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autokool.Data.DrivingSchool
{
    public sealed class UserRolesData : BaseData
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public IEnumerable<string> Roles { get; set; }
        public string ManageUserRolesID { get; set; }
    }
}
