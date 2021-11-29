using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class DrivingPracticeRepo : UniqueEntitiesRepo<DrivingPractice, DrivingPracticeData>,
       IDrivingPracticeRepo
    {
        public DrivingPracticeRepo(ApplicationDbContext c) : base(c, c.DrivingPractices) { }
        protected internal override DrivingPractice toDomainObject(DrivingPracticeData d)
            => new DrivingPractice(d);
    }
}
