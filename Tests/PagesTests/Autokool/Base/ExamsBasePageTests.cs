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
    public class ExamsBasePageTests : CommonPageTests<ExamsAdminPage,ViewPage<ExamsAdminPage, IExamRepo, Exam, ExamView, ExamData>>
    {
        protected override string expectedUrl => "/Administrator/Exams";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "ExamTypeID", "ValidFrom", "ValidTo" };

        protected override object createObject()
        {
            return new ExamsAdminPage(MockRepos.ExamRepos(), MockRepos.ExamTypeRepos());
        }
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "ExamTypeID")
            {
                areEqual("Unspecified", actual);
            }
            else
            {
                base.validateValue(actual, expected);
            }
        }
    }
}
