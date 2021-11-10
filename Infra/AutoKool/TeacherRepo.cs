using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class TeacherRepo : UniqueEntitiesRepo<Teacher, TeacherData>,
      ITeacherRepo
    {
        public TeacherRepo(ApplicationDbContext c) : base(c, c.Teachers) { }
        protected internal override Teacher toDomainObject(TeacherData d)
            => new Teacher(d);
    }
}
