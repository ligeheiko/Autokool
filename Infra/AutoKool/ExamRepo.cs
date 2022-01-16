using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class ExamRepo : UniqueEntitiesRepo<Exam, ExamData>,
      IExamRepo
    {
        public ExamRepo(ApplicationDbContext c) : base(c, c.Exams) { }
        protected internal override Exam toDomainObject(ExamData d) => new (d);
        public async Task Added(Exam e)
        {
            var d = e?.Data;
            if (d == null) return;
            d.ValidFrom = DateTime.Now;
            await Update(new Exam(d));
        }
    }
}