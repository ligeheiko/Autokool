using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Base
{
    public abstract class ExamsBasePage<Tpage> : ViewPage<Tpage, IExamRepo, Exam, ExamView, ExamData>
        where Tpage : PageModel
    {
        public IEnumerable<SelectListItem> ExamTypes { get; }
        public ExamsBasePage(IExamRepo r, IExamTypeRepo e) : base(r, "Exams")
        {
            ExamTypes = newItemsList<ExamType, ExamTypeData>(e);
        }
        public string ExamTypeName(string id) => itemName(ExamTypes, id);
        protected override Uri pageUrl() => new Uri("/Administrator/Exams", UriKind.Relative);
        protected internal override Exam toObject(ExamView v) => new ExamViewFactory().Create(v);
        protected internal override ExamView toView(Exam o) => new ExamViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Name);
            createColumn(x => Item.ExamTypeID);
            //createColumn(x => Item.Passed); //ToDo tee checkbox passedile
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<Tpage> html, int i)
        {
            return i switch
            {
                2 or 3 => getName<DateTime?>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<Tpage> html, int i)
        {
            return i switch
            {
                1 => getRaw(html, ExamTypeName(Item.ExamTypeID)),
                2 or 3 => getValue<DateTime?>(html, i),
                _ => base.GetValue(html, i)
            };
        }
        public override async Task<IActionResult> OnPostCreateAsync(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue);
            Exam e = await db.Get(Item.ID);
            await db.Added(e);
            return Redirect(IndexUrl.ToString());
        }
    }
}