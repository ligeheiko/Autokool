using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public sealed class CourseTypesAdminPage : CourseTypesBasePage<CourseTypesAdminPage>
    {
        public CourseTypesAdminPage(ICourseTypeRepo ct) : base(ct) { }
    }
}
