using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    [Authorize(Roles = "Student")]
    public class ExamsStudentPage : ExamsBasePage<ExamsStudentPage>
    {
        public ExamsStudentPage(IExamRepo e, IExamTypeRepo et) : base(e, et) { }
        protected override Uri pageUrl() => new Uri("/Student/Exams", UriKind.Relative);

        public override async Task<IActionResult> OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue, bool isRegistered)
        {
            getRegistered();
            SelectedId = id;
            setIsRegistered(isRegistered);
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
            return Page();
        }

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
           int pageIndex,
           string fixedFilter, string fixedValue, bool register)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
            register = true;
            setIsRegistered(register);
            return Page();
            //TODO registreerimis nupule vajutades saab admin vaadata kes on registreerinud
        }
    }
}
