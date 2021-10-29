using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class CourseRepo : UniqueEntitiesRepo<Course, CourseData>,
       ICourseRepo
    {
        public CourseRepo(ApplicationDbContext c) : base(c, c.Courses) { }
        protected internal override Course toDomainObject(CourseData d)
            => new Course(d);
    }
}
