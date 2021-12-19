using Autokool.Infra;
using Microsoft.EntityFrameworkCore;

namespace Autokool.Tests.InfraTests
{
    internal class InMemoryApplicationDbContext
    {
        public ApplicationDbContext AppDb;
        public InMemoryApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDb").Options;
            AppDb = new ApplicationDbContext(options);
        }
    }
}
