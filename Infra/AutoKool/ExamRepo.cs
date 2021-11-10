using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class ExamRepo : UniqueEntitiesRepo<Exam, ExamData>,
      IExamRepo
    {
        public ExamRepo(ApplicationDbContext c) : base(c, c.Exams) { }
        protected internal override Exam toDomainObject(ExamData d)
            => new Exam(d);
    }
}
