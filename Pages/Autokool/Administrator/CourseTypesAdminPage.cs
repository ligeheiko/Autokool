using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;

namespace Autokool.Pages.Autokool.Administrator
{
    public class CourseTypesAdminPage : CourseTypesBasePage<CourseTypesAdminPage>
    {
        public CourseTypesAdminPage(ICourseTypeRepo ct) : base(ct) { }
    }
}
