using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class ManageUserRolesRepo : UniqueEntitiesRepo<ManageUserRoles, ManageUserRolesData>
        , IManageUserRolesRepo
    {
        public ManageUserRolesRepo(ApplicationDbContext c) : base(c, c.ManageUserRoles) { }
        protected internal override ManageUserRoles toDomainObject(ManageUserRolesData d)
        => new ManageUserRoles(d);
    }
}
