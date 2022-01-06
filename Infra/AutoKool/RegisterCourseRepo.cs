using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.Common;
using System.Threading.Tasks;

namespace Autokool.Infra.AutoKool
{
    public sealed class RegisterCourseRepo : RegisterRepo<RegisterCourse, RegisterCourseData, IRegisterCourseRepo>,
       IRegisterCourseRepo
    {
        public RegisterCourseRepo(ApplicationDbContext c) : base(c, c.RegisterCourses) { }
        protected internal override RegisterCourse toDomainObject(RegisterCourseData d)
        => new RegisterCourse(d);
        public override async Task RegisterDataToUser(RegisterCourseData rData, ApplicationUser currentUser, IRegisterCourseRepo r, string id)
        {
            rData.CourseID = id;
            await base.RegisterDataToUser(rData, currentUser, r, id);
        }
    }
}