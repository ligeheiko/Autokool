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
    public class RegisteredDrivingPracticeAdminPageTests : AuthorizedPageTests<RegisteredDrivingPracticeAdminPage,ViewPage<RegisteredDrivingPracticeAdminPage, 
        IRegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeView, RegisterDrivingPracticeData>>
    {
        protected override object createObject()
        {
            return new RegisteredDrivingPracticeAdminPage(MockRepos.RegisterDrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
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
