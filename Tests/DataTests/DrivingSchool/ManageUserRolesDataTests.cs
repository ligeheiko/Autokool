using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class ManageUserRolesDataTests : SealedTests<NamedEntityData>
    {
        [TestMethod]
        public void RoleIdTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void RoleNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void SelectedTest()
        {
            isProperty<bool>(false);
        }
    }
}
