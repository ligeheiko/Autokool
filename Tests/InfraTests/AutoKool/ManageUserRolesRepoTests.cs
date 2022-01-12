using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class ManageUserRolesRepoTests :
        RepoTests<ManageUserRolesRepo, ManageUserRoles, ManageUserRolesData>
    {
        protected override object createObject() => new ManageUserRolesRepo(new InMemoryApplicationDbContext().AppDb);
        protected override ManageUserRoles toObject(ManageUserRolesData data) => new(data);
    }
}