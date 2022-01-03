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
    public class CoursesBasePageTests : CommonPageTests<CoursesAdminPage,ViewPage<CoursesAdminPage, ICourseRepo, Course, CourseView, CourseData>>
    {
        protected override object createObject()
        {
            return new CoursesAdminPage(MockRepos.CourseRepos(), MockRepos.CourseTypeRepos());
        }
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