using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public sealed class ExamTypesAdminPage : ExamTypesBasePage<ExamTypesAdminPage>
    {
        public ExamTypesAdminPage(IExamTypeRepo et) : base(et) { }
    }
}
