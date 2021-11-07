using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Facade.DrivingSchool;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Autokool.Pages.Autokool
{
    public class CoursesPage : ViewPage<CoursesPage, ICourseRepo, Course, CourseView, CourseData>
    {
        public CoursesPage(ICourseRepo r) : base(r, "Courses") { }
        protected override Uri pageUrl() => new Uri("/Administrator/Courses", UriKind.Relative);
        protected internal override Course toObject(CourseView v) => new CourseViewFactory().Create(v);
        protected internal override CourseView toView(Course o) => new CourseViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.CourseName);
            createColumn(x => Item.CourseTypeID);
            createColumn(x => Item.Location);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<CoursesPage> html, int i)
        {
            if (i == 4 || i==5 )
            {
                return html.DisplayNameFor(Columns[i] as Expression<Func<CoursesPage, DateTime>>);
            }
            return base.GetName(html, i);
        }
        public override IHtmlContent GetValue(IHtmlHelper<CoursesPage> html, int i)
        {
            if (i == 4 || i == 5)
            {
                return html.DisplayFor(Columns[i] as Expression<Func<CoursesPage, DateTime>>);
            }
            return base.GetValue(html, i);
        }
    }
}
