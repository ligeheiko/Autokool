using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;

namespace Autokool.Pages.Autokool.Admin
{
    public class CoursesAdminPage : CoursesBasePage<CoursesAdminPage>
    {
        public CoursesAdminPage(ICourseRepo c, ICourseTypeRepo ct) : base(c, ct) { }
    }
}
