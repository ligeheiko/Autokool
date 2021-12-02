using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class UserRolesRepo : UniqueEntitiesRepo<UserRoles, UserRolesData>, IUserRolesRepo
    {
        public UserRolesRepo(ApplicationDbContext c) : base(c, c.RolesUser) { }
        protected internal override UserRoles toDomainObject(UserRolesData d)
        => new UserRoles(d);
    }
}
