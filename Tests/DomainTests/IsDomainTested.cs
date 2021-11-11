using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Autokool.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
        protected override string assembly => "Autokool.Domain";
        [TestMethod]
        public void IsCommonTested()
            => isAllTested(assembly, nameSpace("Common"));
        [TestMethod]
        public void IsModelTested()
            => isAllTested(assembly, nameSpace("DrivingSchool.Model"));
    }
}
