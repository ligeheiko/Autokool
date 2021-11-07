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
    public class ExamsPage : ViewPage<ExamsPage, IExamRepo, Exam, ExamView, ExamData>
    {
        public ExamsPage(IExamRepo r) : base(r, "Exams") { }
        protected override Uri pageUrl() => new Uri("/Administrator/Exams", UriKind.Relative);
        protected internal override Exam toObject(ExamView v) => new ExamViewFactory().Create(v);
        protected internal override ExamView toView(Exam o) => new ExamViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.ExamName);
            createColumn(x => Item.ExamTypeID);
            //createColumn(x => Item.Passed);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<ExamsPage> html, int i)
        {
            if (i == 3 || i == 4)
            {
                return html.DisplayNameFor(Columns[i] as Expression<Func<ExamsPage, DateTime>>);
            }
            return base.GetName(html, i);
        }
        public override IHtmlContent GetValue(IHtmlHelper<ExamsPage> html, int i)
        {
            if (i == 3 || i == 4)
            {
                return html.DisplayFor(Columns[i] as Expression<Func<ExamsPage, DateTime>>);
            }
            return base.GetValue(html, i);
        }
    }
}
