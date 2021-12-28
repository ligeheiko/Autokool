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
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Data.DrivingSchool;

namespace Autokool.Tests.PagesTests.Common
{
    [TestClass]
    public class CrudPageTests : 
        AbstractTests<BasePage<ITeacherRepo, Teacher, TeacherView, TeacherData>>
    {
        private class testClass :
            CrudPage<ITeacherRepo, Teacher, TeacherView, TeacherData>
        {
            public testClass(ITeacherRepo r) : base(r) { }
            protected override void setPageValues(string sortOrder, string searchString, in int? pageIndex)
            {
                throw new NotImplementedException();
            }

            protected override Teacher toObject(TeacherView v)
            {
                throw new NotImplementedException();
            }

            protected override TeacherView toView(Teacher o)
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
