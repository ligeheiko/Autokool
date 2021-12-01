using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autokool.Infra
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdministratorData> Administrators { get; set; }
        public DbSet<CourseData> Courses { get; set; }
        public DbSet<CourseTypeData> CourseTypes { get; set; }
        public DbSet<ExamData> Exams { get; set; }
        public DbSet<ExamTypeData> ExamTypes { get; set; }
        public DbSet<PersonRoleData> PersonRoles { get; set; }
        //public DbSet<RoleTypeData> RoleTypes { get; set; } /vaja vist 2 FK
        public DbSet<SchoolData> Schools { get; set; }
        public DbSet<StudentData> Students { get; set; }
        public DbSet<TeacherData> Teachers { get; set; }
        public DbSet<DrivingPracticeData> DrivingPractices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AdministratorData>().ToTable("Administrator");
            builder.Entity<CourseData>().ToTable("Course");
            builder.Entity<CourseTypeData>().ToTable("CourseType");
            builder.Entity<ExamData>().ToTable("Exam");
            builder.Entity<ExamTypeData>().ToTable("ExamType");
            builder.Entity<SchoolData>().ToTable("School");
            builder.Entity<PersonRoleData>().ToTable("PersonRole");
            builder.Entity<StudentData>().ToTable("Student");
            builder.Entity<TeacherData>().ToTable("Teacher");
            builder.Entity<DrivingPracticeData>().ToTable("DrivingPractice");
            //builder.Entity<PersonData>().ToTable("Person");???
        }
    }
}
