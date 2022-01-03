using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Base
{
    public abstract class CoursesBasePage<TPage> : ViewPage<TPage, ICourseRepo, Course, CourseView, CourseData>
        where TPage : PageModel
    {
        public IEnumerable<SelectListItem> CourseTypes { get; }
        public CoursesBasePage(ICourseRepo r, ICourseTypeRepo c) : base(r, "Courses")
        {
            CourseTypes = newItemsList<CourseType, CourseTypeData>(c);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/Courses", UriKind.Relative);
        public string CourseTypeName(string id) => itemName(CourseTypes, id);
        protected internal override Course toObject(CourseView v) => new CourseViewFactory().Create(v);
        protected internal override CourseView toView(Course o) => new CourseViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Name);
            createColumn(x => Item.CourseTypeID);
            createColumn(x => Item.Location);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                3 or 4 => getName<DateTime?>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                1 => getRaw(html, CourseTypeName(Item?.CourseTypeID)),
                3 or 4 => getValue<DateTime?>(html, i),
                _ => base.GetValue(html, i)
            };
        }
        public override async Task<IActionResult> OnPostCreateAsync(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            Course c = await db.Get(Item.ID);
            await db.Added(c);
            return Redirect(IndexUrl.ToString());
        }
    }
}
