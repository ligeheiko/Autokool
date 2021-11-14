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

namespace Autokool.Pages.Autokool.Students
{
    public class StudentsPage : ViewPage<StudentsPage, IStudentRepo, Student, StudentView, StudentData>
    {
        public IEnumerable<SelectListItem> Courses { get; }
        public StudentsPage(IStudentRepo s, ICourseRepo c) : base(s, "My Data")
        {
            Courses = newItemsList<Course, CourseData>(c);
        }
        protected override Uri pageUrl() => new Uri("/Student/Students", UriKind.Relative);
        public string CourseName(string id) => itemName(Courses, id);
        protected internal override Student toObject(StudentView v) => new StudentViewFactory().Create(v);
        protected internal override StudentView toView(Student o) => new StudentViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.FirstName);
            createColumn(x => Item.LastName);
            createColumn(x => Item.CourseID);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
            createColumn(x => Item.Email);
        }
        public override string GetName(IHtmlHelper<StudentsPage> html, int i)
        {
            return i switch
            {
                3 or 4 => getName<DateTime>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<StudentsPage> html, int i)
        {
            return i switch
            {
                2 => getRaw(html, CourseName(Item.CourseID)),
                3 or 4 => getValue<DateTime>(html, i),
                _ => base.GetValue(html, i)
            };
        }
    }
}
