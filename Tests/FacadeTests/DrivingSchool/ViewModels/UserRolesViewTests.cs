using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class UserRolesViewTests : SealedTests<BaseView>
    {
        [TestMethod]
        public void UserIdTest() => isDisplayProperty<string>("UserId");
        [TestMethod]
        public void FirstNameTest() => isDisplayProperty<string>("First Name");
        [TestMethod]
        public void LastNameTest() => isDisplayProperty<string>("Last Name");
        [TestMethod]
        public void UserNameTest() => isDisplayProperty<string>("UserName");
        [TestMethod]
        public void EmailTest() => isDisplayProperty<string>("Email");
        [TestMethod]
        public void RolesTest() => isDisplayProperty<IEnumerable<string>>("Roles");
    }
}