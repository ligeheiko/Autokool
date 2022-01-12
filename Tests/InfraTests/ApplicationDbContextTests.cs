using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests
{
    [TestClass]
    public class ApplicationDbContextTests : ClassTests<IdentityDbContext<ApplicationUser>>
    {
        private class testClass : ApplicationDbContext
        {
            public testClass(DbContextOptions<ApplicationDbContext> o) : base(o) { }
            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }
        protected override object createObject() => new InMemoryApplicationDbContext().AppDb;
        [TestMethod]
        public void CoursesTest() => isProperty<DbSet<CourseData>>();
        [TestMethod]
        public void CourseTypesTest() => isProperty<DbSet<CourseTypeData>>();
        [TestMethod]
        public void ExamsTest() => isProperty<DbSet<ExamData>>();
        [TestMethod]
        public void ExamTypesTest() => isProperty<DbSet<ExamTypeData>>();
        [TestMethod]
        public void TeachersTest() => isProperty<DbSet<TeacherData>>();
        [TestMethod]
        public void DrivingPracticesTest() => isProperty<DbSet<DrivingPracticeData>>();
        [TestMethod]
        public void RolesUserTest() => isProperty<DbSet<UserRolesData>>();
        [TestMethod]
        public void RegisterCoursesTest() => isProperty<DbSet<RegisterCourseData>>();
        [TestMethod]
        public void RegisterExamsTest() => isProperty<DbSet<RegisterExamData>>();
        [TestMethod]
        public void RegisterDrivingPracticesTest() => isProperty<DbSet<RegisterDrivingPracticeData>>();
        [TestMethod]
        public void ManageUserRolesTest() => isProperty<DbSet<ManageUserRolesData>>();

        [TestMethod]
        public void InitializeTablesTest() 
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDb").Options;
            var builder = new testClass(options).RunOnModelCreating();
            testEntity<CourseData>(builder);
            testEntity<CourseTypeData>(builder);
            testEntity<ExamData>(builder);
            testEntity<ExamTypeData>(builder);
            testEntity<DrivingPracticeData>(builder);
            testEntity<TeacherData>(builder);
            testEntity<UserRolesData>(builder);
            testEntity<ManageUserRolesData>(builder);
            testEntity<RegisterCourseData>(builder);
            testEntity<RegisterExamData>(builder);
            testEntity<RegisterDrivingPracticeData>(builder);
        }
        private void testEntity<T>(ModelBuilder b)
        {
            var name = typeof(T).FullName ?? string.Empty;
            var entity = b.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name);
        }
    }
}