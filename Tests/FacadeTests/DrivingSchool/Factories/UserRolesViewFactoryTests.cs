using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class UserRolesViewFactoryTests : FactoryBaseTests<UserRolesViewFactory, UserRolesData, UserRoles, UserRolesView>
    {
        protected override UserRoles createObject(UserRolesData d) => new UserRoles(d);
    }
}