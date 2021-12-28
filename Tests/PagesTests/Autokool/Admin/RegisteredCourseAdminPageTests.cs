using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredCourseAdminPageTests : SealedTests<ViewPage<RegisteredCourseAdminPage
        , IRegisterCourseRepo, RegisterCourse, RegisterCourseView, RegisterCourseData>>
    {
        protected override object createObject()
        {
            return new RegisteredCourseAdminPage(MockRepos.RegisterCourseRepos(), MockRepos.CourseRepos());
        }
    }
}
