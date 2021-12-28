using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.PagesTests
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {
        protected override string assembly => "Autokool.Pages";
        [TestMethod]
        public void IsCommonTested()
            => isAllTested(assembly, nameSpace("Common"));
        [TestMethod]
        public void IsAutokoolTested()
            => isAllTested(assembly, nameSpace("AutoKool"));
        [TestMethod]
        public void IsAdminTested()
            => isAllTested(assembly, nameSpace("AutoKool.Admin"));
        [TestMethod]
        public void IsBaseTested()
            => isAllTested(assembly, nameSpace("AutoKool.Base"));
        [TestMethod]
        public void IsStudentTested()
            => isAllTested(assembly, nameSpace("AutoKool.Students"));
    }
}