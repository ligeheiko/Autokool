using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    public class DrivingPracticeStudentPage : DrivingPracticeBasePage<DrivingPracticeStudentPage>
    {
        public DrivingPracticeStudentPage(IDrivingPracticeRepo d, ITeacherRepo t) : base(d, t) { }
        protected override Uri pageUrl() => new Uri("/Student/DrivingPractices", UriKind.Relative);
        public override async Task OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue, bool isRegistered)
        {
            getRegistered();
            SelectedId = id;
            setIsRegistered(isRegistered);
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
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
