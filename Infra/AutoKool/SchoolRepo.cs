using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class SchoolRepo : UniqueEntitiesRepo<School, SchoolData>,
      ISchoolRepo
    {
        public SchoolRepo(ApplicationDbContext c) : base(c, c.Schools) { }
        protected internal override School toDomainObject(SchoolData d)
            => new School(d);
    }
}
