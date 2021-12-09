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
    public abstract class DrivingPracticeBasePage<TPage> : ViewPage<TPage, IDrivingPracticeRepo, DrivingPractice, DrivingPracticeView, DrivingPracticeData>
        where TPage : PageModel
    {
        public IEnumerable<SelectListItem> Teachers { get; }
        public DrivingPracticeBasePage(IDrivingPracticeRepo d, ITeacherRepo t) : base(d, "Driving practices")
        {
            Teachers = newItemsList<Teacher, TeacherData>(t);
        }
        protected override Uri pageUrl() => new Uri("/Administrator/DrivingPractices", UriKind.Relative);
        public string TeacherName(string id) => itemName(Teachers, id);
        protected internal override DrivingPractice toObject(DrivingPracticeView v) => new DrivingPracticeViewFactory().Create(v);
        protected internal override DrivingPracticeView toView(DrivingPractice o) => new DrivingPracticeViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.TeacherID);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override string GetName(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                1 or 2 => getName<DateTime?>(html, i),
                _ => base.GetName(html, i)
            };
        }
        public override IHtmlContent GetValue(IHtmlHelper<TPage> html, int i)
        {
            return i switch
            {
                0 => getRaw(html, TeacherName(Item.TeacherID)),
                1 or 2 => getValue<DateTime?>(html, i),
                _ => base.GetValue(html, i)
            };
        }
    }
}