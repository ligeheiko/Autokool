using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredCourseAdminPageTests : AuthorizedPageTests<ViewPage<RegisteredCourseAdminPage
        , IRegisterCourseRepo, RegisterCourse, RegisterCourseView, RegisterCourseData>>
    {
        protected override object createObject()
        {
            return new RegisteredCourseAdminPage(MockRepos.RegisterCourseRepos(), MockRepos.CourseRepos());
        }
        protected override string expectedUrl => "/Administrator/RegisterCourse";
        protected override List<string> expectedIndexTableColumns
            => new() { "CourseID", "UserId", "UserName" };
    }
}
