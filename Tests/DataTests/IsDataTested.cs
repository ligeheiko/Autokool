using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        protected override string assembly => "Autokool.Data";
        [TestMethod]
        public void IsCommonTested()
            => isAllTested(assembly, nameSpace("Common"));
        [TestMethod]
        public void IsDrivingSchoolTested()
            => isAllTested(assembly, nameSpace("DrivingSchool"));
    }
}
