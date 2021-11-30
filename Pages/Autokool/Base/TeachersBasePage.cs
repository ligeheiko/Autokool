using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Autokool.Pages.Autokool.Base
{
    public abstract class TeachersBasePage<TPage> : ViewPage<TPage, ITeacherRepo, Teacher, TeacherView, TeacherData>
        where TPage : PageModel
    {
        //public IEnumerable<SelectListItem> Students { get; }
        public TeachersBasePage(ITeacherRepo t/*, IStudentRepo s*/) : base(t, "Teachers")
        {
            //Students = newItemsList<Student, StudentData>(s);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/Teachers", UriKind.Relative);
        //public string StudentName(string id) => itemName(Students, id);
        protected internal override Teacher toObject(TeacherView v) => new TeacherViewFactory().Create(v);
        protected internal override TeacherView toView(Teacher o) => new TeacherViewFactory().Create(o);
        protected override void createTableColumns()
        {
            //createColumn(x => Item.StudentID);
            createColumn(x => Item.FullName);
            createColumn(x => Item.Email);
            createColumn(x => Item.PhoneNr);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                3 or 4 => getName<DateTime>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                //2 => getRaw(html, StudentName(Item.StudentID)),
                3 or 4 => getValue<DateTime>(html, i),
                _ => base.GetValue(html, i)
            };
        }
    }
}
