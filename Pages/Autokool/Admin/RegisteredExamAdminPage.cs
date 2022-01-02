using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public sealed class RegisteredExamAdminPage : ViewPage<RegisteredExamAdminPage, IRegisterExamRepo, RegisterExam, RegisterExamView, RegisterExamData>
    {
        public IEnumerable<SelectListItem> Exams { get; }
        public RegisteredExamAdminPage(IRegisterExamRepo r, IExamRepo c) : base(r, "Users registered for Exam")
        {
            Exams = newItemsList<Exam, ExamData>(c);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/RegisterExam", UriKind.Relative);
        public string ExamName(string id) => itemName(Exams, id);
        protected internal override RegisterExam toObject(RegisterExamView v) => new RegisterExamViewFactory().Create(v);
        protected internal override RegisterExamView toView(RegisterExam o) => new RegisterExamViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ExamID);
            createColumn(x => Item.UserId);
            createColumn(x => Item.UserName);
        }
        public override IHtmlContent GetValue(IHtmlHelper<RegisteredExamAdminPage> html, int i)
        {
            return i switch
            {
                0 => getRaw(html, ExamName(Item.ExamID)),
                _ => base.GetValue(html, i)
            };
        }
    }
}