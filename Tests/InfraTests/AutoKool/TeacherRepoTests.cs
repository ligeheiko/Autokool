using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Infra.AutoKool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class TeacherRepoTests :
        RepoTests<TeacherRepo,Teacher, TeacherData>
    {
        protected override object createObject() => new TeacherRepo(new InMemoryApplicationDbContext().AppDb);
        protected override Teacher toObject(TeacherData data) => new(data);
        [TestMethod]
        public async Task CreateValidFromTest()
        {
            var dt1 = DateTime.Now.AddSeconds(-1);
            await repo.CreateValidFrom(item);
            var dt2 = DateTime.Now.AddSeconds(1);
            var d = await dbSet.FindAsync(item.ID);
            areEqualProperties(d, item.Data, nameof(item.Data.ValidFrom));
            isTrue(d.ValidFrom > dt1);
            isTrue(d.ValidFrom < dt2);
        }
    }
}