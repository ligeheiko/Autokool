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
    public class RegisterDrivingPracticeAdminPage : ViewPage<RegisterDrivingPracticeAdminPage, IRegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeView, RegisterDrivingPracticeData>
    {
        public IEnumerable<SelectListItem> Teachers { get; }
        public RegisterDrivingPracticeAdminPage(IRegisterDrivingPracticeRepo r, ITeacherRepo t) : base(r, "Users registered for Driving Practice")
        {
            Teachers = newItemsList<Teacher, TeacherData>(t);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/RegisterDrivingPractice", UriKind.Relative);
        public string TeacherName(string id) => itemName(Teachers, id);
        protected internal override RegisterDrivingPractice toObject(RegisterDrivingPracticeView v) => new RegisterDrivingPracticeViewFactory().Create(v);
        protected internal override RegisterDrivingPracticeView toView(RegisterDrivingPractice o) => new RegisterDrivingPracticeViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.TeacherID);
            createColumn(x => Item.UserId);
            createColumn(x => Item.UserName);
        }
        public override IHtmlContent GetValue(IHtmlHelper<RegisterDrivingPracticeAdminPage> html, int i)
        {
            return i switch
            {
                0 => getRaw(html, TeacherName(Item.TeacherID)),
                _ => base.GetValue(html, i)
            };
        }
    }
}