using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class ExamTypesBasePageTests : CommonPageTests<ExamTypesAdminPage,ViewPage
        <ExamTypesAdminPage, IExamTypeRepo, ExamType, ExamTypeView, ExamTypeData>>
    {
        protected override string expectedUrl => "/Administrator/ExamTypes";
        protected override List<string> expectedIndexTableColumns
            => new() { "ID", "Name" };

        protected override object createObject()
        {
            return new ExamTypesAdminPage(MockRepos.ExamTypeRepos());
        }
    }
}
