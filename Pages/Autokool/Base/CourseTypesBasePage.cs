using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Autokool.Pages.Autokool.Base
{
    public class CourseTypesBasePage<Tpage> : ViewPage<Tpage, ICourseTypeRepo, CourseType, CourseTypeView, CourseTypeData>
        where Tpage : PageModel
    {
        public CourseTypesBasePage(ICourseTypeRepo r) : base(r, "Course Types") { }
        protected override Uri pageUrl() => new Uri("/Administrator/CourseTypes", UriKind.Relative);
        protected internal override CourseType toObject(CourseTypeView v) => new CourseTypeViewFactory().Create(v);
        protected internal override CourseTypeView toView(CourseType o) => new CourseTypeViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.Name);
        }
    }
}

