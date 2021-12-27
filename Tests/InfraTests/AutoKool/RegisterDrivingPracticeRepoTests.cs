using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterDrivingPracticeRepoTests :
        RepoTests<RegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeData>
    {
        protected override object createObject() => new RegisterDrivingPracticeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterDrivingPractice toObject(RegisterDrivingPracticeData data) => new(data);
    }
}