using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class UserRolesRepoTests :
        RepoTests<UserRolesRepo,UserRoles, UserRolesData>
    {
        protected override object createObject() => new UserRolesRepo(new InMemoryApplicationDbContext().AppDb);
        protected override UserRoles toObject(UserRolesData data) => new(data);
    }
}