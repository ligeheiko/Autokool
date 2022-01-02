using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class TeachersBasePageTests : AbstractTests<ViewPage<TeachersAdminPage, ITeacherRepo, Teacher, TeacherView, TeacherData>>
    {
        private UserManager<ApplicationUser> user;
        protected override object createObject()
        {
            return new TeachersAdminPage(MockRepos.TeacherRepos(), user);
        }
    }
}
