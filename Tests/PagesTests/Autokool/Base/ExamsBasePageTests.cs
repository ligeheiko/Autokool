using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class ExamsBasePageTests : CommonPageTests<ExamsAdminPage,ViewPage<ExamsAdminPage, IExamRepo, Exam, ExamView, ExamData>>
    {
        private IExamTypeRepo examTypes;
        protected override string expectedUrl => "/Administrator/Exams";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "ExamTypeID", "ValidFrom", "ValidTo" };

        protected override object createObject()
        {
            examTypes = addItems<ExamType, ExamTypeData>(MockRepos.ExamTypeRepos(),
                d => new ExamType(d)) as IExamTypeRepo;
            return new ExamsAdminPage(MockRepos.ExamRepos(), examTypes);
        }
        [TestMethod]
        public async Task ExamTypesTest() =>
            await selectListTest(page.ExamTypes, examTypes);

        [TestMethod]
        public async Task ExamTypeNameTest() 
            => await selectNameTest(examTypes, x => page.ExamTypeName(x));

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
