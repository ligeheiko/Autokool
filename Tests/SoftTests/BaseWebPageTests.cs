using Autokool.Domain.Common;
using Autokool.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests
{
    [TestClass]
    public class BaseWebPageTests : TestAssertions
    {
        protected static readonly TestHost<Startup> host;
        protected static readonly HttpClient client;
        
        static BaseWebPageTests()
        {
            host = new TestHost<Startup>();
            client = host.CreateClient();
        }
        [TestMethod]
        public async Task SendRequestTest()
        {
            string html = await getHtml("/Index");
        }

        private async Task<string> getHtml(string url)
        {
            var page = await client.GetAsync(url);
            areEqual(HttpStatusCode.OK, page.StatusCode);
            return await page.Content.ReadAsStringAsync();
        }
        public class TestHost<TStartup> : WebApplicationFactory<TStartup>
            where TStartup : class
        {
            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                base.ConfigureWebHost(builder);
                builder.ConfigureTestServices(
                    x => 
                    {
                        removeCurrentDb<ApplicationDbContext>(x);
                        x.AddEntityFrameworkInMemoryDatabase();
                        addInMemoryDb<ApplicationDbContext>(x);

                        var serviceProvider = x.BuildServiceProvider();
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
        }
    }
}
