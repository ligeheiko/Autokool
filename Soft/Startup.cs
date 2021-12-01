using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra;
using Autokool.Infra.AutoKool;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultUI()
           .AddDefaultTokenProviders();
            services.AddRazorPages();
            RegisterRepos(services);
        }
        private static void RegisterRepos(IServiceCollection s)
        {
            s.AddScoped<ICourseRepo, CourseRepo>();
            s.AddScoped<ICourseTypeRepo, CourseTypeRepo>();
            s.AddScoped<IExamRepo, ExamRepo>();
            s.AddScoped<IExamTypeRepo, ExamTypeRepo>();
            s.AddScoped<IPersonRoleRepo, PersonRoleRepo>();
            s.AddScoped<ISchoolRepo, SchoolRepo>();
            s.AddScoped<IStudentRepo, StudentRepo>();
            s.AddScoped<ITeacherRepo, TeacherRepo>();
            s.AddScoped<IDrivingPracticeRepo, DrivingPracticeRepo>();
            GetRepo.SetServiceProvider(s.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
