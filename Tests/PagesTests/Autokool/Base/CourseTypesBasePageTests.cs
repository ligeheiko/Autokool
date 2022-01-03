using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Base
{
    [TestClass]
    public class CourseTypesBasePageTests : CommonPageTests<CourseTypesAdminPage,ViewPage<CourseTypesAdminPage, ICourseTypeRepo, CourseType, CourseTypeView, CourseTypeData>>
    {
        protected override string expectedUrl => "/Administrator/CourseTypes";
        protected override List<string> expectedIndexTableColumns
            => new() { "ID", "Name" };
        protected override object createObject()
        {
            return new CourseTypesAdminPage(MockRepos.CourseTypeRepos());
        }
    }
}
