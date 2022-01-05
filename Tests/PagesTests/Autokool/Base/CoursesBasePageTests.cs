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
    public class CoursesBasePageTests : CommonPageTests<CoursesAdminPage,ViewPage<CoursesAdminPage, ICourseRepo, Course, CourseView, CourseData>>
    {
        private ICourseTypeRepo courseTypes;
        protected override object createObject()
        {
            courseTypes = addItems<CourseType, CourseTypeData>(MockRepos.CourseTypeRepos(),
                d => new CourseType(d)) as ICourseTypeRepo;
            return new CoursesAdminPage(MockRepos.CourseRepos(), courseTypes);
        }
        [TestMethod]
        public async Task CourseTypesTest() =>
            await selectListTest(page.CourseTypes, courseTypes);

        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "CourseTypeID", "Location", "ValidFrom", "ValidTo" };
        protected override string expectedUrl => "/Administrator/Courses";
        protected override void validateValue(string actual, string expected)
        {
            if (expected == "CourseTypeID")
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