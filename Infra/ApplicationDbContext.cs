using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Soft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdministratorData> Administrators { get; set; }
        public DbSet<CourseData> Courses { get; set; }
        public DbSet<ExamData> Exams { get; set; }
        public DbSet<SchoolData> Schools { get; set; }
        public DbSet<StudentData> Students { get; set; }
        public DbSet<TeacherData> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AdministratorData>().ToTable("Administrator");
            builder.Entity<CourseData>().ToTable("Course");
            builder.Entity<ExamData>().ToTable("Exam");
            builder.Entity<SchoolData>().ToTable("School");
            builder.Entity<StudentData>().ToTable("Student");
            builder.Entity<TeacherData>().ToTable("Teacher");
            //builder.Entity<PersonData>().ToTable("Person");???
        }
    }
}
