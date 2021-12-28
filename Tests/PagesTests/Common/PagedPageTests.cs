using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Infra.AutoKool;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.PagesTests.Common
{
    [TestClass]
    public class PagedPageTests : 
        AbstractTests<CrudPage<ITeacherRepo, Teacher, TeacherView, TeacherData>>
    {
        private class testClass :
           PagedPage<ITeacherRepo, Teacher, TeacherView, TeacherData>
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
