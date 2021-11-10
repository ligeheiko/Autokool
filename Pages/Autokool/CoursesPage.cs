using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Facade.DrivingSchool;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Autokool.Pages.Autokool
{
    public class CoursesPage : ViewPage<CoursesPage, ICourseRepo, Course, CourseView, CourseData>
    {
        public IEnumerable<SelectListItem> CourseTypes { get; }
        public CoursesPage(ICourseRepo r, ICourseTypeRepo c) : base(r, "Courses") 
        {
            CourseTypes = newItemsList<CourseType, CourseTypeData>(c);
        }
        public string CourseTypeName(string id) => itemName(CourseTypes, id);
        protected override Uri pageUrl() => new Uri("/Administrator/Courses", UriKind.Relative);
        protected internal override Course toObject(CourseView v) => new CourseViewFactory().Create(v);
        protected internal override CourseView toView(Course o) => new CourseViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.Name);
            createColumn(x => Item.CourseTypeID);
            createColumn(x => Item.Location);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<CoursesPage> html, int i)
        {
            return i switch
            {
                4 or 5 => getName<DateTime>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<CoursesPage> html, int i)
        {
            return i switch
            {
                2 => getRaw(html, CourseTypeName(Item.CourseTypeID)),
                4 or 5 => getValue<DateTime>(html, i),
                _ => base.GetValue(html, i)
            };
        }
    }
}
