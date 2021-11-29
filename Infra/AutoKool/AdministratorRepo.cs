using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public class AdministratorRepo : UniqueEntitiesRepo<Administrator, AdministratorData>,
      IAdministratorRepo
    {
        public AdministratorRepo(ApplicationDbContext c) : base(c, c.Administrators) { }
        protected internal override Administrator toDomainObject(AdministratorData d)
            => new Administrator(d);
    }
}
