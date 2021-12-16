using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Autokool.Pages.Autokool.Admin
{
    public class RegisteredCourseAdminPage : ViewPage<RegisteredCourseAdminPage, IRegisterCourseRepo, RegisterCourse, RegisterCourseView, RegisterCourseData>
    {
        public IEnumerable<SelectListItem> Courses { get; }
        public RegisteredCourseAdminPage(IRegisterCourseRepo r,ICourseRepo c) : base(r, "Users registered for Course") 
        {
            Courses = newItemsList<Course, CourseData>(c);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/RegisterCourse", UriKind.Relative);
        public string CourseName(string id) => itemName(Courses, id);
        protected internal override RegisterCourse toObject(RegisterCourseView v) => new RegisterCourseViewFactory().Create(v);
        protected internal override RegisterCourseView toView(RegisterCourse o) => new RegisterCourseViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.CourseID);
            createColumn(x => Item.UserId);
            createColumn(x => Item.UserName);
        }
        public override IHtmlContent GetValue(IHtmlHelper<RegisteredCourseAdminPage> html, int i)
        {
            return i switch
            {
                0 => getRaw(html, CourseName(Item.CourseID)),
                _ => base.GetValue(html, i)
            };
        }
    }
}