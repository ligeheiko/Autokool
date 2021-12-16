using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterCourseRepo : UniqueEntitiesRepo<RegisterCourse, RegisterCourseData>,
       IRegisterCourseRepo
    {
        public RegisterCourseRepo(ApplicationDbContext c) : base(c, c.RegisterCourseDatas) { }
        protected internal override RegisterCourse toDomainObject(RegisterCourseData d)
        => new RegisterCourse(d);
    }
}