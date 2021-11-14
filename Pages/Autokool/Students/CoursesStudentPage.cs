using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Students
{
    public class CoursesStudentPage : CoursesBasePage<CoursesStudentPage>
    {
        public CoursesStudentPage(ICourseRepo c, ICourseTypeRepo ct) : base(c, ct) { }
        protected override Uri pageUrl() => new Uri("/Student/Courses", UriKind.Relative);


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
