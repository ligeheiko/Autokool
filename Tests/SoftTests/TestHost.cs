using Autokool.Domain.Common;
using Autokool.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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

                    if (isLogged) addAuthentication(service);
                    var serviceProvider = service.BuildServiceProvider();
                    ensureDbsAreCreated(serviceProvider);
                    GetRepo.SetServiceProvider(serviceProvider);
                }
            );
        }
        private void addAuthentication(IServiceCollection s)
        {
            s.AddAuthentication("Test")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                "Test", options => { });
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
        public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
        {
            public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
                : base(options, logger, encoder, clock)
            {
            }
            protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
                var identity = new ClaimsIdentity(claims, "Test");
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, "Test");

                var result = AuthenticateResult.Success(ticket);

                return Task.FromResult(result);
            }
        }
    }
}
