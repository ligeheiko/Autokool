using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredDrivingPracticeAdminPageTests : AuthorizedPageTests<RegisteredDrivingPracticeAdminPage,ViewPage<RegisteredDrivingPracticeAdminPage, 
        IRegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeView, RegisterDrivingPracticeData>>
    {
        private ITeacherRepo teachers;
        protected override object createObject()
        {
            teachers = addItems<Teacher, TeacherData>(MockRepos.TeacherRepos(),
               d => new Teacher(d)) as ITeacherRepo;
            return new RegisteredDrivingPracticeAdminPage(MockRepos.RegisterDrivingPracticeRepos(), teachers);
        }
        [TestMethod]
        public async Task TeachersTest() =>
           await selectListTest(page.Teachers, teachers);

        protected override string expectedUrl => "/Administrator/RegisterDrivingPractice";
        protected override List<string> expectedIndexTableColumns
            => new() { "TeacherID", "UserId", "UserName" };
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
