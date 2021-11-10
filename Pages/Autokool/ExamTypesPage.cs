﻿using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Repos;
using Autokool.Facade.DrivingSchool;
using Autokool.Pages.Common;
using System;


namespace Autokool.Pages.Autokool
{
    public class ExamTypesPage : ViewPage<ExamTypesPage, IExamTypeRepo, ExamType, ExamTypeView, ExamTypeData>
    {
        public ExamTypesPage(IExamTypeRepo r) : base(r, "ExamTypes") { }
        protected override Uri pageUrl() => new Uri("/Administrator/ExamTypes", UriKind.Relative);
        protected internal override ExamType toObject(ExamTypeView v) => new ExamTypeViewFactory().Create(v);
        protected internal override ExamTypeView toView(ExamType o) => new ExamTypeViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.ID);
            createColumn(x => Item.Name);
        }
    }
}