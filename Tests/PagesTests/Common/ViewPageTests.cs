using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.PagesTests.Common
{
    [TestClass]
    public class ViewPageTests : AbstractTests<UnifiedPage<MockViewPage, 
        ITeacherRepo, Teacher, TeacherView, TeacherData>>
    {
        protected override object createObject()
        {
            return new MockViewPage(MockRepos.TeacherRepos());
        }
    }
    public class MockViewPage : ViewPage<MockViewPage, ITeacherRepo,
                Teacher, TeacherView, TeacherData>
    {
        public MockViewPage(ITeacherRepo r) : base(r, nameof(CourseType) + "s") { }

        protected override void createTableColumns()
        {
            //throw new NotImplementedException();
        }

        protected override Uri pageUrl()
        {
            throw new NotImplementedException();
        }

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
}
