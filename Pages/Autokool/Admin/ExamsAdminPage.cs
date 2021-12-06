using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public class ExamsAdminPage : ExamsBasePage<ExamsAdminPage>
    {
        public ExamsAdminPage(IExamRepo e, IExamTypeRepo et) : base(e, et) { }
    }
}
