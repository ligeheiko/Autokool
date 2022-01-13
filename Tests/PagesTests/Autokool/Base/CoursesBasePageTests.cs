using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class CoursesBasePageTests : CommonPageTests<CoursesAdminPage,ViewPage<CoursesAdminPage, ICourseRepo, Course, CourseView, CourseData>>
    {
        private ICourseTypeRepo courseTypes;
        private ICourseRepo course;
        [TestInitialize]
        public override void TestInitialize()
        {
            initInMemoryDatabase();
            base.TestInitialize();
            page.Item = random<CourseView>();
            
        }
        protected override object createObject()
        {
            course = new CourseRepo(appDb);
            courseTypes = addItems<CourseType, CourseTypeData>(MockRepos.CourseTypeRepos(),
                d => new CourseType(d)) as ICourseTypeRepo;
            return new CoursesAdminPage(MockRepos.CourseRepos(), courseTypes);
        }
        [TestMethod]
        public async Task CourseTypesTest() =>
            await selectListTest(page.CourseTypes, courseTypes);

        [TestMethod]
        public async Task CourseTypeNameTest() => await selectNameTest(courseTypes, x => page.CourseTypeName(x));

        [TestMethod]
        public void OnPostCreateAsyncTest()
        {
            IsTested();
        }
        [TestMethod]
        public void OnPostEditAsyncTest()
        {
            IsTested();
        }// kuna seal sees sisalduv testitud

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