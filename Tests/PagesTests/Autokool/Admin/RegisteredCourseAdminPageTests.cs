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
    public class RegisteredCourseAdminPageTests : AuthorizedPageTests<RegisteredCourseAdminPage,ViewPage<RegisteredCourseAdminPage
        , IRegisterCourseRepo, RegisterCourse, RegisterCourseView, RegisterCourseData>>
    {
        private ICourseRepo courses;
        protected override object createObject()
        {
            courses = addItems<Course, CourseData>(MockRepos.CourseRepos(),
                d => new Course(d)) as ICourseRepo;
            return new RegisteredCourseAdminPage(MockRepos.RegisterCourseRepos(), courses);
        }
        [TestMethod]
        public async Task CoursesTest() =>
            await selectListTest(page.Courses, courses);

        [TestMethod]
        public async Task CourseNameTest() 
            => await selectNameTest(courses, x => page.CourseName(x));

        protected override string expectedUrl => "/Administrator/RegisterCourse";
        protected override List<string> expectedIndexTableColumns
            => new() { "CourseID", "UserId", "UserName" };
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "CourseID")
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
