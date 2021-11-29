using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;

namespace Autokool.Pages.Autokool.Admin
{
    public class DrivingPracticeAdminPage : DrivingPracticeBasePage<DrivingPracticeAdminPage>
    {
        public DrivingPracticeAdminPage(IDrivingPracticeRepo d, ITeacherRepo t) : base(d, t) { }
    }
}
