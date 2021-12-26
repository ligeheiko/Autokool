using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class CourseRepo : UniqueEntitiesRepo<Course, CourseData>,
       ICourseRepo
    {
        public CourseRepo(ApplicationDbContext c) : base(c, c.Courses) { }
        public async Task Added(Course c)
        {
            var d = c?.Data;
            if (d == null) return;
            d.ValidFrom = DateTime.Now;
            await Update(new Course(d));
        }
        protected internal override Course toDomainObject(CourseData d)
    => new Course(d);
    }
}
