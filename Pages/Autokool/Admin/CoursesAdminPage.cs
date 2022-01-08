using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize/*(Roles = "Teacher, Administrator")*/]
    public sealed class CoursesAdminPage : CoursesBasePage<CoursesAdminPage>
    {
        public CoursesAdminPage(ICourseRepo c, ICourseTypeRepo ct) : base(c, ct) { }
    }
}
