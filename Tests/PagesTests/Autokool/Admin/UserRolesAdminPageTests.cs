﻿using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Autokool.Admin;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.PagesTests.Autokool.Admin
{
    [TestClass]
    public class UserRolesAdminPageTests : AuthorizedPageTests<UserRolesAdminPage,ViewPage<UserRolesAdminPage,
        IUserRolesRepo, UserRoles, UserRolesView, UserRolesData>>
    {
        private UserManager<ApplicationUser> user;
        private RoleManager<IdentityRole> roleManager;
        protected override object createObject()
        {
            return new UserRolesAdminPage(user, roleManager, MockRepos.UserRolesRepos());
        }
        protected override string expectedUrl => "/Administrator/UserRoles";
        protected override List<string> expectedIndexTableColumns
            => new() {  };
    }
}