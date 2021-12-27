using Autokool.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.InfraTests
{
    [TestClass]
    public class ConstantsTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(Constants);
        }
        [TestMethod]
        public void DefaultPageSizeTest() => areEqual((byte)5, Constants.DefaultPageSize);
    }
}