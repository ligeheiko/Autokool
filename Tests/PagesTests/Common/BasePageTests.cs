using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autokool.Pages.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Tests.PagesTests.Common
{
    [TestClass]
    public class BasePageTests : AbstractTests<PageModel>
    {
        private class testClass : BasePage<ITeacherRepo, Teacher, TeacherView, TeacherData>
        {
            public testClass(ITeacherRepo r) : base(r) { }
            protected override void setPageValues(string sortOrder, string searchString, in int? pageIndex)
            {
                throw new NotImplementedException();
            }
        }
        protected override object createObject()
        {
            return new testClass(MockRepos.TeacherRepos());
        }
    }
}
