using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredExamAdminPageTests : AuthorizedPageTests<RegisteredExamAdminPage,ViewPage<RegisteredExamAdminPage,
        IRegisterExamRepo, RegisterExam, RegisterExamView, RegisterExamData>>
    {
        private IExamRepo exams;
        protected override object createObject()
        {
            exams = addItems<Exam, ExamData>(MockRepos.ExamRepos(),
                d => new Exam(d)) as IExamRepo;
            return new RegisteredExamAdminPage(MockRepos.RegisterExamRepos(), exams);
        }
        [TestMethod]
        public async Task ExamTest() =>
            await selectListTest(page.Exams, exams);

        [TestMethod]
        public async Task ExamNameTest()
          => await selectNameTest(exams, x => page.ExamName(x));

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