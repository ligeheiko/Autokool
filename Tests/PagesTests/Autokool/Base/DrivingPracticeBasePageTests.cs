using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class DrivingPracticeBasePageTests : AbstractTests<ViewPage<DrivingPracticeAdminPage, IDrivingPracticeRepo, DrivingPractice, DrivingPracticeView, DrivingPracticeData>>
    {
        protected override object createObject()
        {
            return new DrivingPracticeAdminPage(MockRepos.DrivingPracticeRepos(), MockRepos.TeacherRepos());
        }
    }
}
