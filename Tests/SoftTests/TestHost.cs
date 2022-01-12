using Autokool.Domain.Common;
using Autokool.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Autokool.Tests.SoftTests
{
    public class TestHost<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private bool isLogged;
        public TestHost(bool logged = false) : base()
        {
            isLogged = logged;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureTestServices(
                service =>
                {
                    removeCurrentDb<ApplicationDbContext>(service);
                    service.AddEntityFrameworkInMemoryDatabase();
                    addInMemoryDb<ApplicationDbContext>(service);

                    if (isLogged)
                    {
                        service.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                    }
                    var serviceProvider = service.BuildServiceProvider();
                    ensureDbsAreCreated(serviceProvider);
                    GetRepo.SetServiceProvider(serviceProvider);
                }
            );
        }
        private void ensureDbsAreCreated(ServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                ensureDbIsCreated<ApplicationDbContext>(scopedServices);
            }
        }
        private void ensureDbIsCreated<T>(IServiceProvider s)
            where T : DbContext
        {
            var t = typeof(T);
            if (s.GetRequiredService(t) is not DbContext db)
            {
                throw new ApplicationException($"DbContext {t} not found");
            }
            db.Database.EnsureCreated();
            if (!db.Database.IsInMemory())
            {
                throw new ApplicationException($"DbContext {t} is not in memory");
            }
        }
        private void addInMemoryDb<T>(IServiceCollection x)
            where T : DbContext
        {
            x.AddDbContext<T>(o => { o.UseInMemoryDatabase("Tests"); });
        }
        private void removeCurrentDb<T>(IServiceCollection s)
            where T : DbContext
        {
            var descriptor = s.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<T>));
            if (descriptor != null)
            {
                s.Remove(descriptor);
            }
        }
        public class FakePolicyEvaluator : IPolicyEvaluator
        {
            public virtual async Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
            {
                var testScheme = "FakeScheme";
                var principal = new ClaimsPrincipal();
                principal.AddIdentity(new ClaimsIdentity(new[] {
            new Claim("Permission", "CanViewPage"),
            new Claim("Manager", "yes"),
            new Claim(ClaimTypes.Role, "Administrator"),
            new Claim(ClaimTypes.NameIdentifier, "John")
        }, testScheme));
                return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal,
                    new AuthenticationProperties(), testScheme)));
            }

            public virtual async Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy,
                AuthenticateResult authenticationResult, HttpContext context, object resource)
            {
                return await Task.FromResult(PolicyAuthorizationResult.Success());
            }
        }
    }
}
