﻿using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Autokool.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class CoursesAdminPageTests : AuthorizedPageTests<CoursesBasePage<CoursesAdminPage>>
    {
        protected override object createObject()
        {
            return new CoursesAdminPage(MockRepos.CourseRepos(), MockRepos.CourseTypeRepos());
        }
        protected override string expectedUrl => "/Administrator/Courses";
        protected override List<string> expectedIndexTableColumns
            => new() { "Name", "CourseTypeID", "Location", "ValidFrom", "ValidTo" };
    }
}
