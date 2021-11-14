using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;

namespace Autokool.Pages.Autokool.Admin
{
    public class ExamTypesAdminPage : ExamTypesBasePage<ExamTypesAdminPage>
    {
        public ExamTypesAdminPage(IExamTypeRepo et) : base(et) { }
    }
}
