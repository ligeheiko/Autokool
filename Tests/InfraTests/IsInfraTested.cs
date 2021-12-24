using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.InfraTests
{
    [TestClass]
   public class IsInfraTested : AssemblyTests
    {
        protected override string assembly => "Autokool.Infra";
        [TestMethod]
        public void IsCommonTested()
            => isAllTested(assembly, nameSpace("Common"));
        [TestMethod]
        public void IsShopTested()
            => isAllTested(assembly, nameSpace("AutoKool"));
    }
}