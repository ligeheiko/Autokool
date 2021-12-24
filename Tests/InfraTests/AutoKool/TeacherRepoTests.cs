using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class TeacherRepoTests :
        SealedRepoTests<TeacherRepo,Teacher, TeacherData>
    {
        protected override object createObject() => new TeacherRepo(new InMemoryApplicationDbContext().AppDb);
        protected override Teacher toObject(TeacherData data) => new(data);
    }
}