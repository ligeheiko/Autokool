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
    public class DrivingPracticeBasePageTests : CommonPageTests<DrivingPracticeAdminPage,ViewPage<DrivingPracticeAdminPage, IDrivingPracticeRepo, DrivingPractice, DrivingPracticeView, DrivingPracticeData>>
    {
        private ITeacherRepo teachers;
        protected override string expectedUrl => "/Administrator/DrivingPractices";
        protected override List<string> expectedIndexTableColumns
            => new() { "TeacherID","ValidFrom", "ValidTo" };
        protected override object createObject()
        {
            teachers = addItems<Teacher, TeacherData>(MockRepos.TeacherRepos(),
               d => new Teacher(d)) as ITeacherRepo;
            return new DrivingPracticeAdminPage(MockRepos.DrivingPracticeRepos(),teachers);
        }
        [TestMethod]
        public async Task TeachersTest() =>
            await selectListTest(page.Teachers, teachers);

        [TestMethod]
        public async Task TeacherNameTest() 
            => await selectNameTest(teachers, x => page.TeacherName(x));

        protected override void validateValue(string actual, string expected)
        {
            if (expected == "TeacherID")
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
