using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class CourseTypeRepo : UniqueEntitiesRepo<CourseType, CourseTypeData>,
      ICourseTypeRepo
    {
        public CourseTypeRepo(ApplicationDbContext c) : base(c, c.CourseTypes) { }
        protected internal override CourseType toDomainObject(CourseTypeData d) => new (d);
    }
}
