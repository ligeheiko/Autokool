using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autokool.Infra
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CourseData> Courses { get; set; }
        public DbSet<CourseTypeData> CourseTypes { get; set; }
        public DbSet<ExamData> Exams { get; set; }
        public DbSet<ExamTypeData> ExamTypes { get; set; }
        public DbSet<TeacherData> Teachers { get; set; }
        public DbSet<DrivingPracticeData> DrivingPractices { get; set; }
        public DbSet<UserRolesData> RolesUser { get; set; } //teisiti ei saanud nimetata kuna identityDb juba on userRoles
        public DbSet<ManageUserRolesData> ManageUserRoles { get; set; }
        public DbSet<RegisterCourseData> RegisterCourses { get; set; }
        public DbSet<RegisterExamData> RegisterExams { get; set; }
        public DbSet<RegisterDrivingPracticeData> RegisterDrivingPractices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            b.Entity<CourseData>().ToTable("Course");
            b.Entity<CourseTypeData>().ToTable("CourseType");
            b.Entity<ExamData>().ToTable("Exam");
            b.Entity<ExamTypeData>().ToTable("ExamType");
            b.Entity<TeacherData>().ToTable("Teacher");
            b.Entity<DrivingPracticeData>().ToTable("DrivingPractice");
            b.Entity<UserRolesData>().ToTable("UserRole");
            b.Entity<ManageUserRolesData>().ToTable("ManageUserRoles");
            b.Entity<RegisterCourseData>().ToTable("RegisterCourse");
            b.Entity<RegisterExamData>().ToTable("RegisterExam");
            b.Entity<RegisterDrivingPracticeData>().ToTable("RegisterDrivingPractice");
        }
    }
}
