using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class DrivingPracticeRepoTests :
        RepoTests<DrivingPracticeRepo,DrivingPractice, DrivingPracticeData>
    {
        protected override object createObject() => new DrivingPracticeRepo(new InMemoryApplicationDbContext().AppDb);
        protected override DrivingPractice toObject(DrivingPracticeData data) => new(data);
    }
}