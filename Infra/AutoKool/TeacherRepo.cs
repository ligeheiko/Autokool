using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class TeacherRepo : UniqueEntitiesRepo<Teacher, TeacherData>,
      ITeacherRepo
    {
        public TeacherRepo(ApplicationDbContext c) : base(c, c.Teachers) { }
        protected internal override Teacher toDomainObject(TeacherData d) => new (d);
        public async Task CreateValidFrom(Teacher t)
        {
            var d = t?.Data;
            if (d == null) return;
            d.ValidFrom = DateTime.Now;
            await Update(new Teacher(d));
        }
    }
}