using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;

namespace Autokool.Pages.Autokool.Admin
{
    public class ExamsAdminPage : ExamsBasePage<ExamsAdminPage>
    {
        public ExamsAdminPage(IExamRepo e, IExamTypeRepo et) : base(e, et) { }
    }
}
