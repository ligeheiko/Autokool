using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Facade.DrivingSchool;
using Autokool.Pages.Common;
using System;

namespace Autokool.Pages.Autokool
{
    public class CoursesPage : ViewPage<CoursesPage, ICourseRepo, Course, CourseView, CourseData>
    {
        public CoursesPage(ICourseRepo r) : base(r, "Courses") { }
        protected internal override Uri pageUrl() => new Uri("/Autokool/Courses", UriKind.Relative);
        protected internal override Course toObject(CourseView v) => new CourseViewFactory().Create(v);
        protected internal override CourseView toView(Course o) => new CourseViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.CourseName);
            createColumn(x => Item.CourseTypeID);
            createColumn(x => Item.Location);
        }
    }
}
