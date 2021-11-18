using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DomainTests.Common
{
    [TestClass]
    public class GetRepoTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(GetRepo);
        }
    }
}
