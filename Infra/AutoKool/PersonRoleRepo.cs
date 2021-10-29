using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class PersonRoleRepo : UniqueEntitiesRepo<PersonRole, PersonRoleData>,
      IPersonRoleRepo
    {
        public PersonRoleRepo(ApplicationDbContext c) : base(c, c.PersonRoles) { }
        protected internal override PersonRole toDomainObject(PersonRoleData d)
            => new PersonRole(d);
    }
}
