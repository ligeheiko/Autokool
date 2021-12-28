using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class RegisteredDrivingPracticeAdminPageTests : SealedTests<ViewPage<RegisteredDrivingPracticeAdminPage, 
        IRegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeView, RegisterDrivingPracticeData>>
    {
        protected override object createObject()
        {
            return new RegisteredDrivingPracticeAdminPage(MockRepos.RegisterDrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
    }
}
