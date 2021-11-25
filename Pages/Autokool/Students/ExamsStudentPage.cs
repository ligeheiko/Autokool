using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    public class ExamsStudentPage : ExamsBasePage<ExamsStudentPage>
    {
        public ExamsStudentPage(IExamRepo e, IExamTypeRepo et) : base(e, et) { }
        protected override Uri pageUrl() => new Uri("/Student/Exams", UriKind.Relative);
        protected string buttonText = "";
        public bool registered;

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
        }
        //TODO override see et kui klikkida register nuppu saab opilane registreerida ja saab vastava lehe
    }

}
