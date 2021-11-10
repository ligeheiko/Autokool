using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool;
using Autokool.Pages.Common;
using System;

namespace Autokool.Pages.Autokool
{
    public class CourseTypesPage : ViewPage<CourseTypesPage, ICourseTypeRepo, CourseType, CourseTypeView, CourseTypeData>
    {
        public CourseTypesPage(ICourseTypeRepo r) : base(r, "CourseTypes") {}
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

