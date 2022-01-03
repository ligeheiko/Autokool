using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredExamAdminPageTests : AuthorizedPageTests<RegisteredExamAdminPage,ViewPage<RegisteredExamAdminPage,
        IRegisterExamRepo, RegisterExam, RegisterExamView, RegisterExamData>>
    {
        protected override object createObject()
        {
            return new RegisteredExamAdminPage(MockRepos.RegisterExamRepos(), MockRepos.ExamRepos());
        }
        protected override string expectedUrl => "/Administrator/RegisterExam";
        protected override List<string> expectedIndexTableColumns
            => new() { "ExamID", "UserId", "UserName" };
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "ExamID")
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