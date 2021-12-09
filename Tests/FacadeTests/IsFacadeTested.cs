using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        protected override string assembly => "Autokool.Facade";
        [TestMethod]
        public void IsCommonTested()
            => isAllTested(assembly, nameSpace("Common"));
        [TestMethod]
        public void IsFactoritesTested()
            => isAllTested(assembly, nameSpace("DrivingSchool.Factories"));
        [TestMethod]
        public void IsViewModelsTested()
    => isAllTested(assembly, nameSpace("DrivingSchool.ViewModels"));
    }
}