using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public class DrivingPracticeAdminPage : DrivingPracticeBasePage<DrivingPracticeAdminPage>
    {
        public DrivingPracticeAdminPage(IDrivingPracticeRepo d, ITeacherRepo t) : base(d, t) { }
    }
}
