using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class TeachersBasePageTests : CommonPageTests<TeachersAdminPage,ViewPage<TeachersAdminPage, ITeacherRepo, Teacher, TeacherView, TeacherData>>
    {
        private UserManager<ApplicationUser> user;
        protected override string expectedUrl => "/Administrator/Teachers";
        protected override List<string> expectedIndexTableColumns
            => new() { "FullName", "Email", "PhoneNr", "ValidFrom", "ValidTo" };

        protected override object createObject()
        {
            return new TeachersAdminPage(MockRepos.TeacherRepos(), user);
        }
    }
}
