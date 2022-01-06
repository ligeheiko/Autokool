using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra.AutoKool;
using Autokool.Infra.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.InfraTests.AutoKool
{
    [TestClass]
    public class RegisterCourseRepoTests :
        RepoTests<RegisterCourseRepo, RegisterCourse, RegisterCourseData>
    {
        protected override object createObject() => new RegisterCourseRepo(new InMemoryApplicationDbContext().AppDb);
        protected override RegisterCourse toObject(RegisterCourseData data) => new(data);
        [TestMethod]
        public override void IsInheritedTest()
        {
            areEqual(typeof(RegisterRepo<RegisterCourse, RegisterCourseData, IRegisterCourseRepo>), getBaseClass());
        }
    }
}