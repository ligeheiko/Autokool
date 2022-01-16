using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class ExamTypeRepo : UniqueEntitiesRepo<ExamType, ExamTypeData>,
      IExamTypeRepo
    {
        public ExamTypeRepo(ApplicationDbContext c) : base(c, c.ExamTypes) { }
        protected internal override ExamType toDomainObject(ExamTypeData d) => new (d);
    }
}
