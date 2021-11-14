using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using System;

namespace Autokool.Pages.Autokool.Students
{
    public class ExamsStudentPage : ExamsBasePage<ExamsStudentPage>
    {
        public ExamsStudentPage(IExamRepo e, IExamTypeRepo et) : base(e, et) { }
        protected override Uri pageUrl() => new Uri("/Student/Exams", UriKind.Relative);

        //public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
        //   int pageIndex,
        //   string fixedFilter, string fixedValue)
        //{
        //    await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

        //    return Page();
        //}
        //TODO override see et kui klikkida register nuppu saab opilane registreerida ja saab vastava lehe
    }

}
